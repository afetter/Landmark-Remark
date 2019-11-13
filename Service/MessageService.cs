using AutoMapper;
using Domain.Interface;
using Domain.Model;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
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

        /// <summary>
        /// Add a new Message
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Message> AddMessage(MessageViewModel data)
        {
            var model = mapper.Map<Message>(data);
            var message = await repository.AddAsync(model);
            return message;
        }

        /// <summary>
        /// Update a existing message
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<ResponseEnvelope<Message>> UpdateMessage(int id, MessageViewModel data)
        {
            var result = new ResponseEnvelope<Message>();
            var message = await repository.GetBy(n => n.Id == id);
           
            if (message == null)
            {
                return new ResponseEnvelope<Message>().AddError("Message not found");
            }

            if (message.User != data.User)
            {
                return new ResponseEnvelope<Message>().AddError("You canno't update this message");
            }

            message.Text = data.Text;

            await repository.UpdateAsync(message);
            result.Result = message;

            return result;
        }

        /// <summary>
        /// Get all Messages
        /// </summary>
        /// <returns></returns>
        public IList<MessageViewModel> GetMessages()
        {
            var data = repository.GetAllAsync().ToList();
            return mapper.Map<IList<MessageViewModel>>(data);
        }
    }
}
