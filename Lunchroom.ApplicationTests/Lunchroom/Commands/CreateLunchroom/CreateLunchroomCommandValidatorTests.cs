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

namespace Lunchroom.Application.Lunchroom.Commands.CreateLunchroom.Tests
{
    public class CreateLunchroomCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            //arrange
            var repositoryMock = new Mock<LunchroomRepository>();
            var validator = new CreateLunchroomCommandValidator(repositoryMock.Object);
            var command = new CreateLunchroomCommand()
            {

            };
        }
    }
}