using AutoMapper;
using Lunchroom.Application.ApplicationUser;
using Lunchroom.Application.Lunchroom;
using Lunchroom.Application.Lunchroom.Commands.EditLunchroom;
using Lunchroom.Application.Student;
using Lunchroom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Mappings
{
    public class LunchroomMappingProfile : Profile
    {
        public LunchroomMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<LunchroomDto, Domain.Entities.Lunchroom>()
                 .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new LunchroomContactDetails
                 {
                     City = src.City,
                     Street = src.Street,
                     Phone = src.Phone,
                     PostalCode = src.PostalCode,
                 }));

            CreateMap<Domain.Entities.Lunchroom, LunchroomDto>()
                .ForMember(e => e.IsEditable,opt => opt.MapFrom(src => (src.CreatedById == user.Id && user != null)))
                .ForMember(e => e.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(e => e.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(e => e.Phone, opt => opt.MapFrom(src => src.ContactDetails.Phone));

            CreateMap<LunchroomDto, EditLunchroomCommand>();

            CreateMap<StudentDto, Domain.Entities.Student>().ReverseMap();
        }
    }
}
