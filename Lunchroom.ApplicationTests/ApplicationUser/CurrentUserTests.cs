using Xunit;
using Lunchroom.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Lunchroom.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRoleTest_WithMathingRole_ShouldReturnTrue()
        {
            //arrange

            var currentUser = new CurrentUser("1","test@tests.com",new List<string> { "Admin", "User" });

            // act

            var isInRole = currentUser.IsInRole("Admin");

            //assert

            isInRole.Should().BeTrue();

        }

        [Fact()]
        public void IsInRoleTest_WithNonMathingRole_ShouldReturnFalse()
        {
            //arrange

            var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

            // act

            var isInRole = currentUser.IsInRole("Moderator");

            //assert

            isInRole.Should().BeFalse();

        }

        [Fact()]
        public void IsInRoleTest_WithNonMathingCaseRole_ShouldReturnFalse()
        {
            //arrange

            var currentUser = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

            // act

            var isInRole = currentUser.IsInRole("admin");

            //assert

            isInRole.Should().BeFalse();

        }
    }
}