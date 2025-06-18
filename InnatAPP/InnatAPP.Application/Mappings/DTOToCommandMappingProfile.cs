using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.CQRS.Produtos.Commands;
using InnatAPP.Application.CQRS.Reviews.Commands;

namespace InnatAPP.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProdutoDTO, ProdutoCreateCommand>();
            CreateMap<ProdutoDTO, ProdutoUpdateCommand>();

            CreateMap<ReviewDTO, ReviewCreateCommand>();
            CreateMap<ReviewDTO, ReviewUpdateCommand>();
        }
    }
}