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
    /// <summary>
    /// Must create more scenarios of test. 
    /// Success
    /// Fail
    /// Exception
    /// </summary>
    public class MessageServiceTest

    {


        [Test]
        public void AddMessage_Success()
        {
            var repository = new Mock<IRepository<Message>>();
            var map = new Mock<IMapper>();
            map.Setup(s => s.Map<Message>(It.IsAny<MessageViewModel>())).Returns(new Message());
            var service = new MessageService(repository.Object, map.Object);
            var test = service.AddMessage(new MessageViewModel());
            repository.Verify(v => v.AddAsync(It.IsAny<Message>()));
        }

        [Test]
        public void UpdateMessage_Fail_MessageNotFound()
        {
            var repository = new Mock<IRepository<Message>>();
            var map = new Mock<IMapper>();
            repository.Setup(s => s.GetBy(It.IsAny<Expression<Func<Message, bool>>>())).ReturnsAsync((Message)null);
            var service = new MessageService(repository.Object, map.Object);
            var test = service.UpdateMessage(1, new MessageViewModel());
            Assert.AreEqual(test.Result.Errors[0], "Message not found");
        }

        [Test]
        public void UpdateMessage_Fail_Authorization()
        {
            var repository = new Mock<IRepository<Message>>();
            var map = new Mock<IMapper>();
            repository.Setup(s => s.GetBy(It.IsAny<Expression<Func<Message, bool>>>())).ReturnsAsync(new Message { User = "abc" });
            var service = new MessageService(repository.Object, map.Object);
            var test = service.UpdateMessage(1, new MessageViewModel { User = "XYZ" });
            Assert.AreEqual(test.Result.Errors[0], "You canno't update this message");
        }
    }
}