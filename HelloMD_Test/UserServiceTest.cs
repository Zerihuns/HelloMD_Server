using AutoMapper;
using HelloMD.Dtos;
using HelloMD.Helpers;
using HelloMD.Mapping;
using HelloMD.models;
using HelloMD.Repositories.Interfaces;
using HelloMD.Services;
using HelloMD.Services.Interface;
using Microsoft.Extensions.Options;
using Moq;

namespace HelloMD_Test
{
    public class UserServiceTest
    {
        MapperConfiguration mapperConfig;
        IOptions <AppSettings> _appset;
        IMapper _mapper;

        public UserServiceTest()
        {
            this.mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _appset = Options.Create(new AppSettings { Secret = "Hello this Key For Test 1254" }); ;
            _mapper =  new Mapper(mapperConfig);
        }

        [Fact]
        public void UserService_ShouldBe_Return_Avalible_Accounts()
        {
            //Arrange
            Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();

            var testUser = new User
            {
                UserID = 1,
                FirstName = "Test",
                LastName = "Test",
                Username = "Test"
            };

            _userRepositoryMock.Setup(x => x.Confirm("Test", "Test")).ReturnsAsync(testUser);

            //Act
            IUserService _userService = new UserService(_mapper, _userRepositoryMock.Object, _appset);
            var result = _userService.Authenticate(new AuthenticateRequestDto { Username = "Test", Password = "Test"});

            //Assert
            Assert.NotNull(result.Item1);
            Assert.Equal(result.Item1.UserID, testUser.UserID);
        }

        [Fact]
        public void UserService_Should_Retutn_Null_When_Not_Available()
        {
            //Arrange
            Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
            IMapper _mapper = new Mapper(mapperConfig);
            _userRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(new User());

            //Act
            IUserService _userService = new UserService(_mapper, _userRepositoryMock.Object, _appset);
            var user = _userService.GetById(1);

            //Assert
            Assert.Null(user);
        }
    }
}