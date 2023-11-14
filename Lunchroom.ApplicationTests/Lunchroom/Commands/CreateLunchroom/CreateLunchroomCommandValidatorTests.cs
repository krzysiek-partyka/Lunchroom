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
            var lunchroom = new Meal { Name = "Name" };
            var command = new CreateLunchroomCommand
            {
                Name = "ValidName",
                Description = "Valid Description",
                Phone = "1234567890"
            };

            var repositoryMock = new Mock<ILunchroomRepository>();
            repositoryMock.Setup(r => r.GetMealByName("ValidName")).ReturnsAsync((Meal)null);
            var validator = new CreateLunchroomCommandValidator(repositoryMock.Object);

            // Action
            var result = await validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public async Task Validate_WithNotValidCommand_ShouldHaveValidationError()
        {
            // Arrange
            var lunchroom = new Meal { Name = "Name" };
            var command = new CreateLunchroomCommand
            {
                Name = "ValidName",
                Description = "V",
                Phone = "1"
            };

            var repositoryMock = new Mock<ILunchroomRepository>();
            //repositoryMock.Setup(r => r.GetName("ValidName")).ReturnsAsync(lunchroom);
            var validator = new CreateLunchroomCommandValidator(repositoryMock.Object);

            // Action
            var result = await validator.TestValidateAsync(command);

            // Assert
            //result.ShouldHaveValidationErrorFor(x => x.Name)
            //.WithErrorMessage("Name is not unique Name");
            result.ShouldHaveValidationErrorFor(r => r.Name);
            result.ShouldHaveValidationErrorFor(r => r.Description);
            result.ShouldHaveValidationErrorFor(r => r.Phone);
        }

        [Fact()]
        public async Task Validate_WithExistingName_ShouldHaveValidationError()
        {
            // arrange
            var lunchroom = new Meal { Name = "Name" };
            var command = new CreateLunchroomCommand
            {
                Name = "Name",
                Description = "Description",
                Phone = "123456789"
            };
            var repositoryMock = new Mock<ILunchroomRepository>();
            repositoryMock.Setup(r => r.GetMealByName("Name")).ReturnsAsync(lunchroom);
            var validator = new CreateLunchroomCommandValidator(repositoryMock.Object);

            // action
            var result = validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Name is not unique Name");
        }
    }
}