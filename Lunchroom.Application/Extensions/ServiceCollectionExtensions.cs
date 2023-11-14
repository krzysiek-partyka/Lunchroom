using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lunchroom.Application.ApplicationUser;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Application.Mappings;
using Lunchroom.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Lunchroom.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IUserContext, UserContext>();
        service.AddMediatR(typeof(CreateLunchroomCommand));
        service.AddScoped(provider => new MapperConfiguration(cfg =>
        {
            var scope = provider.CreateScope();
            var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
            cfg.AddProfile(new LunchroomMappingProfile(userContext));
        }).CreateMapper());

        service.AddValidatorsFromAssemblyContaining<CreateLunchroomCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        service.AddScoped<IStudentService, StudentService>();
    }
}