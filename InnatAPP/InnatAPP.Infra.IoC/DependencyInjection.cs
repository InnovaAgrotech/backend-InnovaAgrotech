using MediatR;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using InnatAPP.Infra.Data.Firestore;
using InnatAPP.Application.Mappings;
using InnatAPP.Application.Services;
using Microsoft.EntityFrameworkCore;
using InnatAPP.Infra.Data.UnitOfWork;
using InnatAPP.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Google.Cloud.Firestore;
using InnatAPP.Infra.Data.Jobs;

namespace InnatAPP.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #region repositórios baseados em EF Core

            services.AddScoped<IAvaliadorRepository, AvaliadorRepository>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IEmailAlternativoRepository, EmailAlternativoRepository>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<IMensagemRepository, MensagemRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Firestore Service

            services.AddSingleton<FirestoreService>();

            #endregion

            #region Jobs

            services.AddHostedService<AvaliadorSyncJob>();

            services.AddHostedService<CategoriaSyncJob>();

            services.AddHostedService<EmailAlternativoSyncJob>();

            services.AddHostedService<EmpresaSyncJob>();

            services.AddHostedService<EnderecoSyncJob>();

            services.AddHostedService<MensagemSyncJob>();

            services.AddHostedService<ProdutoSyncJob>();

            services.AddHostedService<ReviewSyncJob>();

            services.AddHostedService<TelefoneSyncJob>();

            services.AddHostedService<UsuarioSyncJob>();

            #endregion

            #region Serviços da camada application

            services.AddScoped<PerfilService>();

            #endregion

            #region AutoMapper e MediatR

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            var myhandlers = AppDomain.CurrentDomain.Load("InnatAPP.Application");
            services.AddMediatR(myhandlers);

            #endregion

            #region Unit of work

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            return services;
        }
    }
}