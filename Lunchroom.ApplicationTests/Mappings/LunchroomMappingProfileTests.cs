using Xunit;
using Lunchroom.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Lunchroom.Application.ApplicationUser;
using AutoMapper;
using Lunchroom.Domain.Entities;
using Lunchroom.Application.Lunchroom;
using FluentAssertions;

namespace Lunchroom.Application.Mappings.Tests
{
    public class LunchroomMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMappingLunchroomDtoToMeal()
        {
            //arrange
            var userContext = new Mock<IUserContext>();
            userContext.Setup(u => u.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg
                => cfg.AddProfile(new LunchroomMappingProfile(userContext.Object)));
            var mapper = configuration.CreateMapper();

            var dto = new LunchroomDto()
            {
                City = "Warsaw",
                Street = "Polna 25",
                PostalCode = "12345",
                Phone = "222000999"
            };



            //action

            var result = mapper.Map<Meal>(dto);

            //assert

            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.Phone.Should().Be("222000999");
            result.ContactDetails.City.Should().Be("Warsaw");
            result.ContactDetails.PostalCode.Should().Be("12345");
            result.ContactDetails.Street.Should().Be("Polna 25");

        }

        [Fact()]
        public void MappingProfileShouldBeMapMealToLunchroomDto()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(u => u.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new LunchroomMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var meal = new Meal()
            {
                Id = 1,
                CreatedById = "1",
                LunchPrice = 6.72m,
                ContactDetails = new LunchroomContactDetails()
                {
                    City = "Warsaw",
                    Street = "Polna 25",
                    PostalCode = "12345",
                    Phone = "222000999"
                }
            };
            // action
            var result = mapper.Map<LunchroomDto>(meal);

            // assert

            result.Should().NotBeNull();
            result.Phone.Should().Be(meal.ContactDetails.Phone);
            result.City.Should().Be(meal.ContactDetails.City);
            result.Street.Should().Be(meal.ContactDetails.Street);
            result.PostalCode.Should().Be(meal.ContactDetails.PostalCode);
            result.IsEditable.Should().BeTrue();
        }
    }
}