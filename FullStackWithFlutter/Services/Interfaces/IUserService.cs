using FullStackWithFlutter.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackWithFlutter.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateNewUser(SaveAppUserViewModel userViewModel);

        Task<List<AppUserViewModel>> GetAllUsers();

        Task<AppUserViewModel> GetUserById(int userId);

        Task<bool> UpdateUser(int userId, SaveAppUserViewModel userViewModel);

        Task<bool> DeleteUser(int userId);
    }
}
