using AutoMapper;
using Map.Comunicator.Domain.Interface;
using Map.Comunicator.Domain.Model;
using Map.Comunicator.Domain.ViewModel;
using Map.Comunicator.Service;
using Moq;
using NUnit.Framework;
using System;

namespace Map.Comunicator.Test
{
    public class UserServiceTest

    {


        [Test]
        public void AddUser_Success()
        {
            var repository = new Mock<IRepository<User>>();
            var map = new Mock<IMapper>();
            map.Setup(s => s.Map<User>(It.IsAny<UserViewModel>())).Returns(new User());
            var service = new UserService(repository.Object, map.Object);
            var test = service.AddUser(new UserViewModel());
            repository.Verify(v => v.AddAsync(It.IsAny<User>()));
        }

        [Test]
        public void AddUser_Fail()
        {
            var repository = new Mock<IRepository<User>>();
            var map = new Mock<IMapper>();
            map.Setup(s => s.Map<User>(It.IsAny<UserViewModel>())).Returns(new User());
            var service = new UserService(repository.Object, map.Object);
            var test = service.AddUser(new UserViewModel());
            repository.Verify(v => v.AddAsync(It.IsAny<User>()));
        }
    }
}