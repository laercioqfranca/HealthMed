﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using HealthMed.Infra.Bus;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Infra.Data.EventSourcing;
using HealthMed.Infra.Data.Context;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Application.AppServices.Administracao;
using HealthMed.Application.Interfaces.Administracao;
using HealthMed.Application.AppServices.Auth;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Domain.Commands.Auth;
using HealthMed.Application.AppServices.Autenticacao;

namespace HealthMed.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Application
            services.AddScoped<IAutenticacaoAppService, AutenticacaoAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPerfilUsuarioAppService, PerfilUsuarioAppService>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AutenticarCommand, Unit>, AutenticacaoCommandHandler>();

            services.AddScoped<IRequestHandler<UsuarioCreateCommand, Unit>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioUpdateCommand, Unit>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioDeleteCommand, Unit>, UsuarioCommandHandler>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStore, EventStore>();

            // Infra - Data
            services.AddDbContext<HealthMedContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>();

            // Infra - Service
        }
    }
}