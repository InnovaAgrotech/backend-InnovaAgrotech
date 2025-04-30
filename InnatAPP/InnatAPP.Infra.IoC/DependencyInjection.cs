using InnatAPP.Domain.Interfaces;
using InnatAPP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using InnatAPP.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnatAPP.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        { 
        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b =>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IAvaliadorRepository, AvaliadorRepository>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IEmailAlternativoAvaliadorRepository, EmailAlternativoAvaliadorRepository>();

            services.AddScoped<IEmailAlternativoEmpresaRepository, EmailAlternativoEmpresaRepository>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IEnderecoAvaliadorRepository, EnderecoAvaliadorRepository>();

            services.AddScoped<IEnderecoEmpresaRepository, EnderecoEmpresaRepository>();

            services.AddScoped<IMensagemRepository, MensagemRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<ITelefoneAvaliadorRepository, TelefoneAvaliadorRepository>();

            services.AddScoped<ITelefoneEmpresaRepository, TelefoneEmpresaRepository>();

            return services;
        }
    }
}