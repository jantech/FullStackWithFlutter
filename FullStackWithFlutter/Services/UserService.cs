using AutoMapper;
using FullStackWithFlutter.Core.Interfaces;
using FullStackWithFlutter.Core.Models;
using FullStackWithFlutter.Core.ViewModels;
using FullStackWithFlutter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackWithFlutter.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateNewUser(SaveAppUserViewModel userViewModel)
        {
            if (userViewModel != null)
            {
                var newUser = _mapper.Map<AppUser>(userViewModel);
                newUser.CreatedDate = DateTime.Now;
                newUser.CreatedBy = "API";
                await _unitOfWork.AppUsers.Add(newUser);

                var result = _unitOfWork.Complete();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<List<AppUserViewModel>> GetAllUsers()
        {
            var userList = await _unitOfWork.AppUsers.GetAll();
            var userListResp = _mapper.Map<List<AppUserViewModel>>(userList);
            return userListResp;
        }

        public async Task<AppUserViewModel> GetUserById(int userId)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.AppUsers.Get(userId);
                if (user != null)
                {
                    var userResp = _mapper.Map<AppUserViewModel>(user);
                    return userResp;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUser(int userId, SaveAppUserViewModel userViewModel)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.AppUsers.Get(userId);
                if (user != null)
                {
                    user.FullName = userViewModel.FullName;
                    user.MobileNumber = userViewModel.MobileNumber;
                    user.UpdatedDate = DateTime.Now;
                    user.UpdatedBy = "API";
                    _unitOfWork.AppUsers.Update(user);

                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.AppUsers.Get(userId);
                if (user != null)
                {
                    _unitOfWork.AppUsers.Delete(user);
                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

    }
}
