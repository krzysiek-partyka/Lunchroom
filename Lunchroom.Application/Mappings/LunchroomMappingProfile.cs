﻿using AutoMapper;
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
            CreateMap<LunchroomDto, Domain.Entities.Meal>()
                 .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new LunchroomContactDetails
                 {
                     City = src.City,
                     Street = src.Street,
                     Phone = src.Phone,
                     PostalCode = src.PostalCode
                 }));

            CreateMap<Domain.Entities.Meal, LunchroomDto>()
                .ForMember(e => e.IsEditable,opt => opt.MapFrom(src => (user != null && (user.IsInRole("Moderator") || src.CreatedById == user.Id) )))
                .ForMember(e => e.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(e => e.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(e => e.Phone, opt => opt.MapFrom(src => src.ContactDetails.Phone))
                .ForMember(e => e.StudentId, opt => opt.MapFrom(src => src.StudentId));

            CreateMap<LunchroomDto, EditLunchroomCommand>();

            CreateMap<StudentDto, Domain.Entities.Student>();

            CreateMap<Domain.Entities.Student, StudentDto>()
                .ForMember(e => e.LunchPrice, opt => opt.MapFrom(src => src.Lunchroom.LunchPrice));
        }
    }
}
