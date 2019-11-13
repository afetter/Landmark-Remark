using Domain.Model;
using Domain.ViewModel;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserService
    {
        Task<ResponseEnvelope<User>> AddUser(UserViewModel data);
        Task<ResponseEnvelope<bool>> Login(UserViewModel data);
    }
}
