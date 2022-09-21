using System.Text.RegularExpressions;

namespace ControleFinanceiro.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpecialCharacters(this string text)
        {
            var reg = new Regex("[*'\",_&#^@]");

            return reg.Replace(text, string.Empty);
        }

        public static string RemoveVowelAccent(this string text)
        {
            string withAccents = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûù";
            string withoutAccents = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuu";

            for (int i = 0; i < withAccents.Length; i++)
                text = text.Replace(withAccents[i].ToString(), withoutAccents[i].ToString());

            return text;
        }
    }
}
