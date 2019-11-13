using AutoMapper;
using Domain.Model;
using Domain.ViewModel;

namespace Service.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
