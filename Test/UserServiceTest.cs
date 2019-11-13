using AutoMapper;
using Domain.Interface;
using Domain.Model;
using Domain.ViewModel;
using Service;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace Test
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
        public void AddUser_Fail_UserExist()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(s => s.ExistsAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(true);
            var service = new UserService(repository.Object, null);
            var test = service.AddUser(new UserViewModel());
            Assert.AreEqual(test.Result.Errors[0], "Users already exist");
        }
    }
}