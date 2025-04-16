using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Shared
{
    public class ConstantesValidacao
    {
        public const string caracteresEspeciaisPermitidosSenha = "! @ # $ % ^ & * ( ) _ - + = { } [ ] ; : < > | / ? ' \" , .";

        public const string caracteresInvalidosEmailUsuario = "( ) [ ] ; : < >  , \\ \"";

        public const string caracteresInvalidosEmailDominio = "! # $ % ^ & * ( ) _ + = { } [ ] ; : < > | / ? ' \" ";
    }
}
