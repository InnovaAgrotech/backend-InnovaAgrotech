using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;

namespace InnatAPP.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Avaliador, AvaliadorDTO>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

            CreateMap<EmailAlternativo, EmailAlternativoDTO>().ReverseMap();

            CreateMap<Empresa, EmpresaDTO>().ReverseMap();

            CreateMap<Endereco, EnderecoDTO>().ReverseMap();

            CreateMap<Mensagem, MensagemDTO>().ReverseMap();

            CreateMap<Produto, ProdutoDTO>().ReverseMap();

            CreateMap<Review, ReviewDTO>().ReverseMap();

            CreateMap<Telefone, TelefoneDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}