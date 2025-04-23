using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Domain.Shared
{
    public class ConstantesValidacao
    {
        public static readonly char[] caracteresEspeciaisPermitidosSenha = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', ';', ':', '<', '>', '|', '/', '?', '\'', '"', ',', '.' };

        public static readonly char [] caracteresInvalidosEmailUsuario = new char[] { '(', ')', '[', ']', ';', ':', '<', '>',  ',', '\\', '"' };

        public static readonly char[] caracteresInvalidosEmailDominio = new char[] { '!', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '{', '}', '[', ']', ';', ':', '<', '>', '|', '/', '?', '\'', '"' };
    }
}
