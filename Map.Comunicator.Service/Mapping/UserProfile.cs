using AutoMapper;
using Map.Comunicator.Domain.Model;
using Map.Comunicator.Domain.ViewModel;

namespace Map.Comunicator.Service.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}
