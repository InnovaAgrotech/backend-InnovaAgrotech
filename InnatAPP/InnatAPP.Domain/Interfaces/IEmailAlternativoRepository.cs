using InnatAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Interfaces
{
    internal interface IEmailAlternativoRepository
    {
            Task<IEnumerable<EmailAlternativo>> BuscarEmailsAlternativosAsync();
            Task<EmailAlternativo> BuscarPorIdAsync(int? id);

            Task<EmailAlternativo> AdicionarAsync(EmailAlternativo emailalternativo);

            Task<EmailAlternativo> AtualizarAsync(EmailAlternativo emailalternativo);

            Task<EmailAlternativo> RemoverAsync(EmailAlternativo emailalternativo);
        }
    }
