using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using InnatAPP.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using InnatAPP.Application.Services;
using InnatAPP.Application.Interfaces;
using InnatAPP.Application.Mappings;
using InnatAPP.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using InnatAPP.Domain.Account;

namespace InnatAPP.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        { 
        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b =>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<IAvaliadorRepository, AvaliadorRepository>();
            services.AddScoped<IAvaliadorService, AvaliadorService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IEmailAlternativoAvaliadorRepository, EmailAlternativoAvaliadorRepository>();
            services.AddScoped<IEmailAlternativoAvaliadorService, EmailAlternativoAvaliadorService>();

            services.AddScoped<IEmailAlternativoEmpresaRepository, EmailAlternativoEmpresaRepository>();
            services.AddScoped<IEmailAlternativoEmpresaService, EmailAlternativoEmpresaService>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IEnderecoAvaliadorRepository, EnderecoAvaliadorRepository>();
            services.AddScoped<IEnderecoAvaliadorService, EnderecoAvaliadorService>();

            services.AddScoped<IEnderecoEmpresaRepository, EnderecoEmpresaRepository>();
            services.AddScoped<IEnderecoEmpresaService, EnderecoEmpresaService>();

            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<IMensagemService, MensagemService>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<ITelefoneAvaliadorRepository, TelefoneAvaliadorRepository>();
            services.AddScoped<ITelefoneAvaliadorService, TelefoneAvaliadorService>();

            services.AddScoped<ITelefoneEmpresaRepository, TelefoneEmpresaRepository>();
            services.AddScoped<ITelefoneEmpresaService, TelefoneEmpresaService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("InnatAPP.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}