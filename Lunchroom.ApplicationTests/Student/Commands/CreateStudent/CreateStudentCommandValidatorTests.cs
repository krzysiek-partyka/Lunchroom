using FluentValidation.TestHelper;
using Xunit;

namespace Lunchroom.Application.Student.Commands.CreateStudent.Tests;

public class CreateStudentCommandValidatorTests
{
    [Fact]
    public void CreateStudent_WithValidCommand_ShouldNotHaveValidationError()
    {
        //arrange
        var validator = new CreateStudentCommandValidator();
        var command = new CreateStudentCommand
        {
            FirstName = "FirsName",
            LastName = "SecondName",
            LunchroomEncodedName = "ecodedName2"
        };

        //action

        var result = validator.TestValidate(command);

        //assert

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void CreateStudent_WithNotValidCommand_ShouldHaveValidationError()
    {
        //arrange
        var validator = new CreateStudentCommandValidator();
        var command = new CreateStudentCommand
        {
            FirstName = "",
            LastName = "",
            LunchroomEncodedName = null
        };

        //action

        var result = validator.TestValidate(command);

        //assert

        result.ShouldHaveValidationErrorFor(r => r.FirstName);
        result.ShouldHaveValidationErrorFor(r => r.LastName);
        result.ShouldHaveValidationErrorFor(r => r.LunchroomEncodedName);
    }
}