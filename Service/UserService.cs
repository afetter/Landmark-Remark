using AutoMapper;
using Domain.Interface;
using Domain.Model;
using Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;
        public UserService(IRepository<User> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<ResponseEnvelope<User>> AddUser(UserViewModel data)
        {
            var result = new ResponseEnvelope<User>();

            var exist = await repository.ExistsAsync(n => n.Username == data.Username);
            if (exist)
            {
                return new ResponseEnvelope<User>().AddError("Users already exist");
            }


            var model = mapper.Map<User>(data);
            var user = await repository.AddAsync(model);
            result.Result = user;
            return result;
        }

        public async Task<ResponseEnvelope<bool>> Login(UserViewModel data)
        {
            var result = new ResponseEnvelope<bool>();

            var exist = await repository.ExistsAsync(n => n.Username == data.Username && n.Pwd == data.Pwd);
            if (!exist)
            {
                return new ResponseEnvelope<bool>().AddError("Users or password not found");
            }

            result.Result = true;
            return result;
        }
    }
}
