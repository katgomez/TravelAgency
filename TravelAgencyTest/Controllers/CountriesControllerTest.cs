using ApplicationServices.Controllers;
using ApplicationServices.Model.Country;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServices;
using DataServices.Model;
using DataServices.Service;
using WSClient.UserWS;

namespace TravelAgencyTest.Controllers
{
    public class CountriesControllerTest
    {
        private readonly CountriesController _controller;
        private readonly UserServices _userService;

        private IConfiguration _configuration;
        

        public CountriesControllerTest() {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            

            //var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: $"temp-{Guid.NewGuid()}");
            _controller = new CountriesController(_configuration);
            //_userService = new UserServices();
        }
        //public static void LoadData(DataContext dataContext)
        //{
        //    var fixture = new Fixture();
        //    fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        //    var user = fixture.CreateMany<User>(25).ToList();
        //    dataContext.Users.AddRange(user);
        //    dataContext.SaveChanges();

        //}

        [Fact]
        public async void GetCountries_ResultOk()
        {
            ActionResult<CountryResultDto> actionResult = await _controller.GetCountries();

            Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);

            var okObjectResult = actionResult.Result as OkObjectResult;
            var countryResultDto = okObjectResult.Value as CountryResultDto;
            int numberResults = countryResultDto.numberResults;
            Assert.Equal(196, numberResults);
        }
    }
}
