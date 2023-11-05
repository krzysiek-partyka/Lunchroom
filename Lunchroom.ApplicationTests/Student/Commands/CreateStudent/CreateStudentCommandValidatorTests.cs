using Xunit;
using Lunchroom.Application.Student.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace Lunchroom.Application.Student.Commands.CreateStudent.Tests
{
    public class CreateStudentCommandValidatorTests
    {
        [Fact()]
        public void CreateStudent_WithValidCommand_ShouldNotHaveValidationError()
        {
            //arrange
            var validator = new CreateStudentCommandValidator();
            var command = new CreateStudentCommand()
            {
                FirstName = "FirsName",
                LastName = "SecondName",
                LunchroomEncodedName = "ecodedName2",

            };

            //action

            var result = validator.TestValidate(command);

            //assert

            result.ShouldNotHaveAnyValidationErrors();

        }

        [Fact()]
        public void CreateStudent_WithNotValidCommand_ShouldHaveValidationError()
        {
            //arrange
            var validator = new CreateStudentCommandValidator();
            var command = new CreateStudentCommand()
            {
                FirstName = "",
                LastName = "",
                LunchroomEncodedName = null,

            };

            //action

            var result = validator.TestValidate(command);

            //assert

            result.ShouldHaveValidationErrorFor(r => r.FirstName);
            result.ShouldHaveValidationErrorFor(r => r.LastName);
            result.ShouldHaveValidationErrorFor(r => r.LunchroomEncodedName);

        }
    }
}