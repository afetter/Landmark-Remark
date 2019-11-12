using AutoMapper;
using Map.Comunicator.Domain.Model;
using Map.Comunicator.Domain.ViewModel;

namespace Map.Comunicator.Service.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageViewModel, Message>().ReverseMap();
        }
    }
}
