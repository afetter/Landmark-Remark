using AutoMapper;
using Domain.Model;
using Domain.ViewModel;

namespace Service.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageViewModel, Message>().ReverseMap();
        }
    }
}
