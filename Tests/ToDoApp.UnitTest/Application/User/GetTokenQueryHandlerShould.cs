using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.User.Queries;
using Xunit;

namespace ToDoApp.UnitTests.Application.User
{
    public class GetTokenQueryHandlerShould
    {
        [Theory]
        [AutoMoqData]
        public async Task ReturnTokenWhenSuccessful(
            GetTokenQuery query,
            string token,
            [Frozen] Mock<IIdentityService> identityServiceMock,
            [Frozen] Mock<ITokenService> tokenServiceMock,
            GetTokenQueryHandler sut)
        {
            identityServiceMock.Setup(call => call.Authenticate(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);
            tokenServiceMock.Setup(call => call.GenerateToken(It.IsAny<string>())).Returns(token);

            var result = await sut.Handle(query, CancellationToken.None);

            result.Should().BeEquivalentTo(token);

            identityServiceMock.Verify(call => call.Authenticate(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
            tokenServiceMock.Verify(call => call.GenerateToken(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public async Task ReturnNullWhenUnableToAuthenticate(
            GetTokenQuery query,
            [Frozen] Mock<IIdentityService> identityServiceMock,
            [Frozen] Mock<ITokenService> tokenServiceMock,
            GetTokenQueryHandler sut)
        {
            identityServiceMock.Setup(call => call.Authenticate(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            var result = await sut.Handle(query, CancellationToken.None);

            result.Should().BeNull();

            identityServiceMock.Verify(call => call.Authenticate(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
            tokenServiceMock.Verify(call => call.GenerateToken(It.IsAny<string>()), Times.Never);
        }
    }
}
