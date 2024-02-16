using DataServices;
using DataServices.DAO;
using DataServices.Model;
using DataServices.Services;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServicesTests.Services
{
    public class UserServicesTests
    {
        [Fact]
        public void CreateUser_UserDoesNotExist_AddsUser()
        {
            // Arrange
            var mockUserDao = new Mock<IUserDAO>();
            mockUserDao.Setup(u => u.All()).Returns(Enumerable.Empty<User>());

            var mockDaoFactory = new Mock<DAOFactory>();
            mockDaoFactory.Setup(f => f.UserDao).Returns(mockUserDao.Object);

            var userServices = new UserServices(mockDaoFactory.Object);

            var newUser = new User { Email = "test@example.com" };

            // Act & Assert
            userServices.CreateUser(newUser);

            // Verify that the Add method of IUserDAO was called once with newUser
            mockUserDao.Verify(u => u.Add(newUser), Times.Once);
        }
    }
}
