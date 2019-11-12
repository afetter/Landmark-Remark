using AutoMapper;
using Map.Comunicator.Domain.Interface;
using Map.Comunicator.Domain.Model;
using Map.Comunicator.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Map.Comunicator.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Message> repository;
        public MessageService(IRepository<Message> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public async Task<Message> AddMessage(MessageViewModel data)
        {
            var model = mapper.Map<Message>(data);
            var message = await repository.AddAsync(model);
            return message;
        }

        public async Task<ResponseEnvelope<Message>> UpdateMessage(int id, MessageViewModel data)
        {
            var result = new ResponseEnvelope<Message>();
            var message = await repository.GetBy(n => n.Id == id);
           
            if (message == null)
            {
                return new ResponseEnvelope<Message>().AddError("Message not found");
            }

            message.Text = data.Text;

            await repository.UpdateAsync(message);
            result.Result = message;

            return result;
        }

        public IList<MessageViewModel> GetMessages()
        {
            var data = repository.GetAllAsync().ToList();
            return mapper.Map<IList<MessageViewModel>>(data);
        }
    }
}
