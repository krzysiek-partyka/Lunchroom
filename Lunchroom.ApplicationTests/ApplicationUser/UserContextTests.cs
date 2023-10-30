using FluentAssertions;
using Lunchroom.Application.ApplicationUser;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lunchroom.ApplicationTests.ApplicationUser
{
    public class UserContextTests
    {
        [Fact]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldBezReturnCurrentUser()
        {
            //arrange
            var currentUserContextMock = new Mock<IHttpContextAccessor>();
            currentUserContextMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { 
                    new Claim(ClaimTypes.NameIdentifier,"2"),
                    new Claim(ClaimTypes.Email, "test@test.com"),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Role, "Moderator")

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
}
