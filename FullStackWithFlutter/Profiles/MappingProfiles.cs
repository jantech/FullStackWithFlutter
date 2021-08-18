using AutoMapper;
using FullStackWithFlutter.Core.Models;
using FullStackWithFlutter.Core.ViewModels;

namespace FullStackWithFlutter.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, SaveAppUserViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserViewModel>().ReverseMap();
        }
    }
}
