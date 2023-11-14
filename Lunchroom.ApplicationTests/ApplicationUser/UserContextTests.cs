using System.Security.Claims;
using FluentAssertions;
using Lunchroom.Application.ApplicationUser;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Lunchroom.ApplicationTests.ApplicationUser;

public class UserContextTests
{
    [Fact]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldBezReturnCurrentUser()
    {
        //arrange
        var currentUserContextMock = new Mock<IHttpContextAccessor>();
        currentUserContextMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext
        {
            User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, "2"),
                    new(ClaimTypes.Email, "test@test.com"),
                    new(ClaimTypes.Role, "Admin"),
                    new(ClaimTypes.Role, "Moderator")
                },
                "Test"))
        });

        var userContext = new UserContext(currentUserContextMock.Object);

        //action
        var currentUser = userContext.GetCurrentUser();

        //assert
        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("2");
        currentUser.Email.Should().Be("test@test.com");
        currentUser.Roles.Should().ContainInOrder("Admin", "Moderator");
    }
}