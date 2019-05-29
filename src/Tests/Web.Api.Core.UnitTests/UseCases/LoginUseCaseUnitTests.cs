using Moq;
using Krola.Web.Api.Core.Dto;
using Krola.Web.Api.Core.Dto.UseCaseRequests;
using Krola.Web.Api.Core.Dto.UseCaseResponses;
using Krola.Web.Api.Core.Interfaces;
using Krola.Web.Api.Core.Interfaces.Gateways.Repositories;
using Krola.Web.Api.Core.Interfaces.Services;
using Krola.Web.Api.Core.UseCases;
using Xunit;
using Krola.Domain.Authorization;

namespace Krola.Web.Api.Core.UnitTests.UseCases
{
    public class LoginUseCaseUnitTests
    {
        [Fact]
        public async void Handle_GivenValidCredentials_ShouldSucceed()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.FindByName(It.IsAny<string>())).ReturnsAsync(new User("","","",""));

            mockUserRepository.Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(factory => factory.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AccessToken("", 0));

            var mockTokenFactory = new Mock<ITokenFactory>();

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object, mockTokenFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("userName", "password","127.0.0.1"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }

        [Fact]
        public async void Handle_GivenIncompleteCredentials_ShouldFail()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.FindByName(It.IsAny<string>())).ReturnsAsync(new User("","","",""));

            mockUserRepository.Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(false);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(factory => factory.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AccessToken("", 0));

            var mockTokenFactory = new Mock<ITokenFactory>();


            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object, mockTokenFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password","127.0.0.1"), mockOutputPort.Object);

            // assert
            Assert.False(response);
            mockTokenFactory.Verify(factory => factory.GenerateToken(32), Times.Never);
        }


        [Fact]
        public async void Handle_GivenUnknownCredentials_ShouldFail()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.FindByName(It.IsAny<string>())).ReturnsAsync((User)null);

            mockUserRepository.Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(factory => factory.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AccessToken("", 0));

            var mockTokenFactory = new Mock<ITokenFactory>();

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object, mockTokenFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password","127.0.0.1"), mockOutputPort.Object);

            // assert
            Assert.False(response);
            mockTokenFactory.Verify(factory => factory.GenerateToken(32), Times.Never);
        }

        [Fact]
        public async void Handle_GivenInvalidPassword_ShouldFail()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.FindByName(It.IsAny<string>())).ReturnsAsync((User)null);

            mockUserRepository.Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(false);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(factory => factory.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AccessToken("", 0));

            var mockTokenFactory = new Mock<ITokenFactory>();

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object, mockTokenFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password","127.0.0.1"), mockOutputPort.Object);

            // assert
            Assert.False(response);
            mockTokenFactory.Verify(factory => factory.GenerateToken(32), Times.Never);
        }
    }
}
