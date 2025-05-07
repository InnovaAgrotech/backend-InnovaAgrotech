using AutoMapper;
using InnatAPP.Application.DTOs;
using InnatAPP.Application.Produtos.Commands;
using InnatAPP.Application.Reviews.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
