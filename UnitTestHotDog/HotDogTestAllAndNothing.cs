using System;
using System.Threading.Tasks;
using WebApplication1.Models;
using Xunit;
using WebApplication1.Repo;
using Moq;
using WebApplication1.Services;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using WebApplication1;
using FluentAssertions;

namespace UnitTestHotDog
{
    public class HotDogTestAllAndNothing
    {
        [Fact]
        public async Task add_hotDog_To_Db()    
        {
            //Arange
            HotDog hotDog = new HotDog() { Name = "£agodny", Phone = 666746759, SauceId = 2 };
            IRepo repo = new Repos();
            //Act
            var hotDogInDb = await repo.AddAsync(hotDog);
            //Assert
            Assert.Equal(hotDogInDb, hotDog);


        }
        [Fact]
        public async Task invoke_create_hotDog()
        {
            //arrange
            var hotDogRepoMock = new Mock<IRepo>();

            //TO DO

            IHotDogService service = new HotDogService(hotDogRepoMock.Object);

            //act
            await service.CreateAsync("Adam", 666746666, 2);

            //assert
            hotDogRepoMock.Verify(x => x.AddAsync(It.IsAny<HotDog>()), Times.Once());

        }
        [Fact]
        public async Task invoke_get_hotDog()
        {
            //arrange
            HotDog hotDog = new HotDog() { Id = 5, Name = "Piotr",  Phone = 2233442 };
            var hotDogRepositoryMock = new Mock<IRepo>();
            IHotDogService service = new HotDogService(hotDogRepositoryMock.Object);

            hotDogRepositoryMock.Setup(x => x.GetAsync(hotDog.Id)).ReturnsAsync(hotDog);
            //act
            var customerDto = await service.GetAsync(hotDog.Id);

            //assert
            hotDogRepositoryMock.Verify(x => x.GetAsync(hotDog.Id), Times.Once());

            //TO DO

            customerDto.Should().NotBeNull();
            customerDto.Id.Equals(hotDog.Id);
        }
    }
    //public class HotDogControllerTest
    //{
    //    private readonly TestServer _server;
    //    private readonly HttpClient _client;

    //    public HotDogControllerTest()
    //    {
    //        ////TO DO
    //        //_server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
    //        //_client = _server.CreateClient();
    //    }

    //    [Fact]
    //    public async Task fetching()
    //    {
    //        var response = await _client.GetAsync("api/Customer");
    //    }
    //}
}
