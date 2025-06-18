using InnatAPP.Application.Interfaces;
using InnatAPP.Application.Mappings;
using InnatAPP.Application.Services;
using InnatAPP.Domain.Account;
using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using InnatAPP.Infra.Data.Identity;
using InnatAPP.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAvaliadorRepository, AvaliadorFirestoreRepository>();
            services.AddScoped<IAvaliadorService, AvaliadorService>();

            services.AddScoped<ICategoriaRepository, CategoriaFirestoreRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IEmailAlternativoAvaliadorRepository, EmailAlternativoAvaliadorRepository>();
            services.AddScoped<IEmailAlternativoAvaliadorService, EmailAlternativoAvaliadorService>();

            services.AddScoped<IEmailAlternativoEmpresaRepository, EmailAlternativoEmpresaRepository>();
            services.AddScoped<IEmailAlternativoEmpresaService, EmailAlternativoEmpresaService>();

            services.AddScoped<IEmpresaRepository, EmpresaFirestoreRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddScoped<IEnderecoAvaliadorRepository, EnderecoAvaliadorRepository>();
            services.AddScoped<IEnderecoAvaliadorService, EnderecoAvaliadorService>();

            services.AddScoped<IEnderecoEmpresaRepository, EnderecoEmpresaRepository>();
            services.AddScoped<IEnderecoEmpresaService, EnderecoEmpresaService>();

            services.AddScoped<IMensagemRepository, MensagemFirestoreRepository>();
            services.AddScoped<IMensagemService, MensagemService>();

            services.AddScoped<IProdutoRepository, ProdutoFirestoreRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IReviewRepository, ReviewFirestoreRepository>();
            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<ITelefoneAvaliadorRepository, TelefoneAvaliadorRepository>();
            services.AddScoped<ITelefoneAvaliadorService, TelefoneAvaliadorService>();

            services.AddScoped<ITelefoneEmpresaRepository, TelefoneEmpresaRepository>();
            services.AddScoped<ITelefoneEmpresaService, TelefoneEmpresaService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("InnatAPP.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
