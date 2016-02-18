using System.Web.Mvc;
using AutoMapper;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.MapperProfiles.Extentions;
using DNTCms.Utility;
using DNTCms.ViewModel.Administrator.User;

namespace DNTCms.MapperProfiles
{
    public class UserProfile : Profile
    {

        protected override void Configure()
        {
            CreateMap<User, UserViewModel>()
                .IgnoreAllNonExisting();

            CreateMap<AddUserViewModel, User>()
                .ForMember(d => d.Email, m => m.MapFrom(s => s.Email.FixGmailDots()))
                .IgnoreAllNonExisting();

            CreateMap<EditUserViewModel, User>()
                .ForMember(d => d.Roles, m => m.Ignore())
                .ForMember(d => d.Email, m => m.MapFrom(s => s.Email.FixGmailDots()))
                .IgnoreAllNonExisting();

            CreateMap<User, EditUserViewModel>().ForMember(d => d.Roles, m => m.Ignore())
                .IgnoreAllNonExisting();

            CreateMap<User, SelectListItem>()
                .ForMember(d => d.Text, m => m.MapFrom(s => s.UserName))
                .ForMember(d => d.Value, m => m.MapFrom(s => s.Id)).IgnoreAllNonExisting();
        }

        public override string ProfileName => GetType().Name;
    }
}

