using FluentAssertions;
using Lunchroom.Domain.Entities;
using Xunit;

namespace Lunchroom.Application.ApplicationUser.Tests;

public class CurrentUserTests
{
    [Fact]
    public void IsInRoleTest_WithMathingRole_ShouldReturnTrue()
    {
        //arrange

        var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

        // act

        var isInRole = currentUser.IsInRole(Role.Admin);

        //assert

        isInRole.Should().BeTrue();
    }

    [Fact]
    public void IsInRoleTest_WithNonMathingRole_ShouldReturnFalse()
    {
        //arrange

        var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

        // act

        var isInRole = currentUser.IsInRole(Role.Moderator);

        //assert

        isInRole.Should().BeFalse();
    }

    [Fact]
    public void IsInRoleTest_WithNonMathingCaseRole_ShouldReturnFalse()
    {
        //arrange

        var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

        // act

        var isInRole = currentUser.IsInRole(Role.Admin);

        //assert

        isInRole.Should().BeFalse();
    }
}