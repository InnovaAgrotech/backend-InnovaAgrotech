using MediatR;
using InnatAPP.Domain.Entities;

namespace InnatAPP.Application.CQRS.Avaliadores.Queries
{
    public class GetAvaliadorByEmailQuery : IRequest<Avaliador>
    {
        public string Email { get; set; }
        public GetAvaliadorByEmailQuery(string email)
        {
            Email = email;
        }
    }
}