using AutoFixture;
using DataServices;
using DataServices.Errors;
using DataServices.Model;
using DataServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.ServiceModel;

namespace DataServicesTests.Services
{
    public class UserServicesTests
    {
        private readonly DataContext fakeDataContext;
        private readonly UserServices userServices;

        public UserServicesTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(
                databaseName: $"temp-{Guid.NewGuid()}").Options;
            fakeDataContext = new DataContext(options);
            fakeDataContext.Database.EnsureDeleted();
            AddUserData(fakeDataContext);
            userServices = new UserServices(fakeDataContext);
        }

        private static void AddUserData(DataContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var users = fixture.CreateMany<User>(15).ToList();
            dataContextFake.Users.AddRange(users);
            dataContextFake.SaveChanges();
        }

        [Fact]
        public void GetUsers_ResultOkObject()
        {
            var actionResult = userServices.GetUsers();
            Assert.NotNull(actionResult);
            Assert.Equal(15d, actionResult.Count(), 0);
        }

        [Fact]
        public void GetUser_ResultNotFound()
        {
            string email = "";
            Assert.Throws<NotFoundException>(() => userServices.GetUserByEmail(email));
        }

        [Fact]
        public void GetValidUser_ResultOkObject()
        {
            User user = new User
            {
                Email = "Newdummy@dummy.com",
                Password = "newdummy"
            };
            string email = "";
            Assert.Throws<NotFoundException>(() => userServices.GetUserByEmail(email));
        }

        [Fact]
        public void CreateUser_ValidUser_ReturnsUserId()
        {
            User user = new User
            {
                FirstName = "dummy",
                LastName = "dummy",
                Email = "Newdummy@dummy.com",
                Password = "newdummy"
            };
            int userId = userServices.CreateUser(user);
            Assert.NotEqual(-1, userId); 
        }

        [Fact]
        public void CreateUser_InvalidUser_ReturnsFailure()
        {
            User user = new User
            {
                FirstName = "dummy",
                Email = "Newdummy@dummy.com",
            };
            var userId = userServices.CreateUser(user);
            Assert.Equal(-1, userId);
        }

        [Fact]
        public void CreateUser_UserAlreadyExists_ThrowsFaultException()
        {
            DataContext dataContext = new DataContext();
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var user = fixture.Create<User>();
            dataContext.Users.AddRange(user);
            dataContext.SaveChanges();
            int userId = user.Id;
            UserServices userServices = new UserServices(dataContext);
            User newUser = new User
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password
            }; 
            Assert.Throws<FaultException>(() => userServices.CreateUser(newUser));
        }
        [Fact]
        public void UpdateUser_UserExists_UpdateSuccessful()
        {
            DataContext dataContext = new DataContext();
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var user = fixture.Create<User>();
            dataContext.Users.AddRange(user);
            dataContext.SaveChanges();
            UserServices userServices = new UserServices(dataContext);

            User updatedUser = new User { Id = user.Id, FirstName = "Updated", LastName = "User" };

            userServices.UpdateUser(updatedUser);

            var userInDatabase = dataContext.Users.FirstOrDefault(u => u.Id == user.Id);
            Assert.NotNull(userInDatabase);
            Assert.Equal(updatedUser.FirstName, userInDatabase.FirstName);
            Assert.Equal(updatedUser.LastName, userInDatabase.LastName);
            
        }

        [Fact]
        public void UpdateUser_UserNotFound_ThrowsFaultException()
        {
            var nonExistingUserId = 1000;
            var updatedUser = new User { Id = nonExistingUserId, FirstName = "Updated", LastName = "User" };
            var exception = Assert.Throws<FaultException>(() => userServices.UpdateUser(updatedUser));
            Assert.Equal("User not found!!!", exception.Reason.GetMatchingTranslation().Text);
        }

        [Fact]
        public void DeleteUser_UserExists_DeletesSuccessfully()
        {
            DataContext dataContext = new DataContext();
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var user = fixture.Create<User>();
            dataContext.Users.AddRange(user);
            dataContext.SaveChanges();
            UserServices userServices = new UserServices(dataContext);
            userServices.DeleteUser(user.Id);
            var deletedUser = fakeDataContext.Users.FirstOrDefault(u => u.Id == user.Id);
            Assert.Null(deletedUser); 
            
        }

        [Fact]
        public void DeleteUser_UserDoesNotExist_ThrowsFaultException()
        {
            var nonExistingUserId = 1000;
            var exception = Assert.Throws<FaultException>(() => userServices.DeleteUser(nonExistingUserId));
            Assert.Equal("User not found!!!", exception.Reason.GetMatchingTranslation().Text);
        }
    }
}
