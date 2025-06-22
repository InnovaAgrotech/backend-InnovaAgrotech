using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.CQRS.Reviews.Commands;
using InnatAPP.Application.CQRS.Produtos.Commands;
using InnatAPP.Application.CQRS.Empresas.Commands;
using InnatAPP.Application.CQRS.Usuarios.Commands;
using InnatAPP.Application.CQRS.Enderecos.Commands;
using InnatAPP.Application.CQRS.Mensagens.Commands;
using InnatAPP.Application.CQRS.Telefones.Commands;
using InnatAPP.Application.CQRS.Categorias.Commands;
using InnatAPP.Application.CQRS.Avaliadores.Commands;
using InnatAPP.Application.CQRS.EmailsAlternativos.Commands;
using InnatAPP.Application.DTOs.Usuario;

namespace InnatAPP.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<AvaliadorDTO, AvaliadorCreateCommand>();

            CreateMap<CategoriaDTO, CategoriaCreateCommand>();
            CreateMap<CategoriaDTO, CategoriaUpdateCommand>();

            CreateMap<EmailAlternativoDTO, EmailAlternativoCreateCommand>();
            CreateMap<EmailAlternativoDTO, EmailAlternativoUpdateCommand>();

            CreateMap<EmpresaDTO, EmpresaCreateCommand>();

            CreateMap<EnderecoDTO, EnderecoCreateCommand>();
            CreateMap<EnderecoDTO, EnderecoUpdateCommand>();

            CreateMap<MensagemDTO, MensagemCreateCommand>();

            CreateMap<ProdutoDTO, ProdutoCreateCommand>();
            CreateMap<ProdutoDTO, ProdutoUpdateCommand>();

            CreateMap<ReviewDTO, ReviewCreateCommand>();
            CreateMap<ReviewDTO, ReviewUpdateCommand>();

            CreateMap<TelefoneDTO, TelefoneCreateCommand>();
            CreateMap<TelefoneDTO, TelefoneUpdateCommand>();

            CreateMap<UsuarioCreateDTO, UsuarioCreateCommand>()
                .ForMember(dest => dest.SenhaHash, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.TipoUsuarioTexto, opt => opt.MapFrom(src => src.TipoUsuarioTexto));
            CreateMap<UsuarioUpdateDTO, UsuarioUpdateCommand>();
        }
    }
}