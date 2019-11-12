using Map.Comunicator.Domain.Model;
using Map.Comunicator.Domain.ViewModel;
using System.Threading.Tasks;

namespace Map.Comunicator.Domain.Interface
{
    public interface IUserService
    {
        Task<ResponseEnvelope<User>> AddUser(UserViewModel data);
        Task<ResponseEnvelope<bool>> Login(UserViewModel data);
    }
}
