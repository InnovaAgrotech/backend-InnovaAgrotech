using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Avaliador, AvaliadorDTO>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaProdutosDTO>().ReverseMap();

            CreateMap<EmailAlternativoAvaliador, EmailAlternativoAvaliadorDTO>().ReverseMap();

            CreateMap<EmailAlternativoEmpresa, EmailAlternativoEmpresaDTO>().ReverseMap();

            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaProdutosDTO>().ReverseMap();

            CreateMap<EnderecoAvaliador, EnderecoAvaliadorDTO>().ReverseMap();

            CreateMap<EnderecoEmpresa, EnderecoEmpresaDTO>().ReverseMap();

            CreateMap<Mensagem, MensagemDTO>().ReverseMap();

            CreateMap<Produto, ProdutoDTO>().ReverseMap();

            CreateMap<Review, ReviewDTO>().ReverseMap();

            CreateMap<TelefoneAvaliador, TelefoneAvaliadorDTO>().ReverseMap();

            CreateMap<TelefoneEmpresa, TelefoneEmpresaDTO>().ReverseMap();
        }
    }
}
