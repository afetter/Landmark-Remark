using Map.Comunicator.Domain.Model;
using Map.Comunicator.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Map.Comunicator.Domain.Interface
{
    public interface IMessageService
    {
        Task<ResponseEnvelope<Message>> UpdateMessage(int id, MessageViewModel data);
        Task<Message> AddMessage(MessageViewModel data);
        IList<MessageViewModel> GetMessages();
    }
}
