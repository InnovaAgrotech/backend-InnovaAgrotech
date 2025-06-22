using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using InnatAPP.Infra.Data.Services;
using InnatAPP.Infra.Data.Identity;
using InnatAPP.Application.Mappings;
using InnatAPP.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using InnatAPP.Infra.Data.UnitOfWork;
using InnatAPP.Application.Interfaces;
using InnatAPP.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnatAPP.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

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

            #region Serviços 

            services.AddScoped<IAvaliadorService, AvaliadorService>();

            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IEmailAlternativoService, EmailAlternativoService>();

            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IMensagemService, MensagemService>();

            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<ITelefoneService, TelefoneService>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            /* #region Firestore Service

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

            #endregion */

            #region Serviços da camada infradata

            services.AddScoped<IServicoHash, ServicoHash>();

            #endregion

            #region AutoMapper e MediatR

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("InnatAPP.Application")));

            #endregion

            #region Unit of work

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            return services;
        }
    }
}