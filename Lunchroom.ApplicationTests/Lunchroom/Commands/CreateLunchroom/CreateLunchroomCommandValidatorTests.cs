using Xunit;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunchroom.Domain.Interfaces;
using Lunchroom.Infrastructure.Repositories;
using Moq;
using FluentValidation.TestHelper;
using Lunchroom.Domain.Entities;

namespace Lunchroom.Application.Lunchroom.Commands.CreateLunchroom.Tests
{
    public class CreateLunchroomCommandValidatorTests
    {
        [Fact()]
        public async Task Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            // Arrange
            var command = new CreateLunchroomCommand
            {
                Name = "ValidName",
                Description = "Valid Description",
                Phone = "1234567890"
            };

            var repositoryMock = new Mock<ILunchroomRepository>();
            repositoryMock.Setup(r => r.GetName("ValidName")).ReturnsAsync((Meal)null);
            var validator = new CreateLunchroomCommandValidator(repositoryMock.Object);

            // Action
            var result = await validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}