using AutoMapper;
using InnatAPP.Domain.Entities;
using InnatAPP.Application.DTOs;
using InnatAPP.Domain.ValueObjects;
using InnatAPP.Application.DTOs.Usuario;
using InnatAPP.Application.DTOs.Produto;

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

            CreateMap<Produto, ProdutoDTO>().ReverseMap()
                    .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa))
                    .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria)); ;

            CreateMap<Review, ReviewDTO>().ReverseMap();

            CreateMap<Telefone, TelefoneDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioRespostaDTO>()
                 .ForMember(dest => dest.TipoUsuarioTexto, opt => opt.MapFrom(src => src.TipoUsuario.Valor));
        }
    }
}