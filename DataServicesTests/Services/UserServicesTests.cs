using AutoFixture;
using DataServices;
using DataServices.DAO.Impl;
using DataServices.Model;
using DataServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataServicesTests.Services
{
    public class UserServicesTests
    {
        private readonly DAOFactory daoFactory;
        private readonly UserServices userServices;
        public UserServicesTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(
                databaseName: $"temp-{Guid.NewGuid()}").Options;
            var fakeDataContext = new DataContext(options);
            fakeDataContext.Database.EnsureDeleted();
            AddUserData(fakeDataContext);
            daoFactory = new DAOFactory(fakeDataContext);
            userServices = new UserServices(daoFactory);
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
        public void GetUser_ResultOkObject()
        {
            var actionResult = userServices.GetUsers();
            Debug.WriteLine($"Result: {actionResult}");
            Console.WriteLine($"Result: {actionResult}");
            Assert.NotNull(actionResult);
            Assert.Equal(15d, actionResult.Count(), 0);
        }
    }
}
