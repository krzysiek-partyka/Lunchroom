using Xunit;
using Lunchroom.Application.Student.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lunchroom.Domain.Entities;
using Moq;
using Lunchroom.Application.ApplicationUser;
using Lunchroom.Domain.Interfaces;
using FluentAssertions;
using MediatR;

namespace Lunchroom.Application.Student.Commands.CreateStudent.Tests
{
    public class CreateStudentCommandHandlerTests
    {
        [Fact()]
        public async Task Handle_CreateStudent_WhenUserIsAuthorized()
        {
            //arrange
            var lunchroom = new Meal()
            {
                Id = 1,
                CreatedById = "1"
            };

            var command = new CreateStudentCommand()
            {
                FirstName = "testName1",
                LastName = "testName2",
                NumberOfLunches = 3,
                LunchPrice = 5.50m,
                ClassroomName = ClassroomName.V,
                Payment = 11,
                LunchroomEncodedName = "lunchroomName1"
            };

            var contextUserMock = new Mock<IUserContext>();
            contextUserMock.Setup(x => x.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "User" }));

            var studentRepositoryMock = new Mock<IStudentRepository>();
            var lunchroomRepositoryMock = new Mock<ILunchroomRepository>();
            lunchroomRepositoryMock.Setup(x => x.GetStudentByEncodedName(command.LunchroomEncodedName))
                .ReturnsAsync(lunchroom);

            var handler = new CreateStudentCommandHandler(studentRepositoryMock.Object, contextUserMock.Object, lunchroomRepositoryMock.Object);

            //action
            var result = await handler.Handle(command, CancellationToken.None);

            //assert

            result.Should().Be(Unit.Value);
            studentRepositoryMock.Verify(x => x.CreateStudent(It.IsAny<Domain.Entities.Student>()), Times.Once);

        }

        [Fact()]
        public async Task Handle_CreateStudent_WhenUserIsModerator()
        {
            //arrange
            var lunchroom = new Meal()
            {
                Id = 1,
                CreatedById = "1"
            };

            var command = new CreateStudentCommand()
            {
                FirstName = "testName1",
                LastName = "testName2",
                NumberOfLunches = 3,
                LunchPrice = 5.50m,
                ClassroomName = ClassroomName.V,
                Payment = 11,
                LunchroomEncodedName = "lunchroomName1"
            };

            var contextUserMock = new Mock<IUserContext>();
            contextUserMock.Setup(x => x.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var studentRepositoryMock = new Mock<IStudentRepository>();
            var lunchroomRepositoryMock = new Mock<ILunchroomRepository>();
            lunchroomRepositoryMock.Setup(x => x.GetStudentByEncodedName(command.LunchroomEncodedName))
                .ReturnsAsync(lunchroom);

            var handler = new CreateStudentCommandHandler(studentRepositoryMock.Object, contextUserMock.Object, lunchroomRepositoryMock.Object);

            //action
            var result = await handler.Handle(command, CancellationToken.None);

            //assert

            result.Should().Be(Unit.Value);
            studentRepositoryMock.Verify(x => x.CreateStudent(It.IsAny<Domain.Entities.Student>()), Times.Once);

        }
    }
}