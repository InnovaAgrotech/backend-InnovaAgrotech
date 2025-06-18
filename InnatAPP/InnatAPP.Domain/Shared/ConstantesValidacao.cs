using System.Text.RegularExpressions;

namespace InnatAPP.Domain.Shared
{
    public class ConstantesValidacao
    {
        #region Caracteres Especiais

        public static readonly char[] CaracteresEspeciaisPermitidosSenha = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', ';', ':', '<', '>', '|', '/', '?', '\'', '"', ',', '.' };

        public static readonly char [] CaracteresInvalidosEmailUsuario = new char[] { '(', ')', '[', ']', ';', ':', '<', '>',  ',', '\\', '"' };

        public static readonly char[] CaracteresInvalidosInicioFimEmailUsuario = new char[] { '!', '#', '$', '%', '&', '\'', '*', '+', '/', '=', '?', '^', '`', '{', '|', '}', '~' };

        public static readonly char[] CaracteresInvalidosEmailDominio = new char[] { '!', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '{', '}', '[', ']', ';', ':', '<', '>', '|', '/', '?', '\'', '"', '\\', '~', '`','^' };

        #endregion

        #region Caracteres Consecutivos

        public static readonly Regex PontosConsecutivos = new(@"\.{2,}");

        public static readonly Regex HifensConsecutivos = new(@"-{2,}");

        public static readonly Regex UnderscoresConsecutivos = new(@"_{2,}");

        public static readonly Regex EspacosConsecutivos = new(@"\s{2,}");

        #endregion
    }
}