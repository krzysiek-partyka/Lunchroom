using Xunit;
using Lunchroom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Lunchroom.Domain.Entities.Tests
{
    public class MealTests
    {
        [Fact()]
        public void EncodeName_ShoudlBeSetEncodedName()
        {
            var lunchroom = new Meal();

            lunchroom.Name = "Encoded Name Test";
            lunchroom.EncodeName();
            
            lunchroom.EncodedName.Should().Be("encoded-name-test");

        }
        [Fact()]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            var lunchroom =new Meal();

            Action action = () => lunchroom.EncodeName();

            action.Invoking(a => a.Invoke()).Should().Throw<NullReferenceException>();
        }
    }
}