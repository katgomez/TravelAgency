using AutoFixture;
using DataServices;
using DataServices.Model;
using DataServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataServicesTests.Services
{
    public class UserServicesTests
    {
        private readonly UserServices userServices;
        public UserServicesTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(
                databaseName: $"temp-{Guid.NewGuid()}").Options;
            var fakeDataContext = new DataContext(options);
            fakeDataContext.Database.EnsureDeleted();
            AddUserData(fakeDataContext);
            userServices = new UserServices();
        }

        private static void AddUserData(DataContext dataContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var user = fixture.CreateMany<User>(15).ToList();
            dataContextFake.Users.AddRange(user);
            dataContextFake.SaveChanges();
        }

        [Fact]
        public void GetUser_ResultOkObject()
        {
            var actionResult = userServices.GetUsers();
            Assert.NotNull(actionResult);
            Assert.Equal(15d, actionResult.Count(), 0);
        }
    }
}
