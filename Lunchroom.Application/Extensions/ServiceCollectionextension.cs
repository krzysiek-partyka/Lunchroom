using FluentValidation;
using FluentValidation.AspNetCore;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Application.Mappings;
using Lunchroom.Application.Services;
using Lunchroom.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(typeof(CreateLunchroomCommand));
            service.AddAutoMapper(typeof(LunchroomMappingProfile));
            service.AddValidatorsFromAssemblyContaining<CreateLunchroomCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
