using System.Text.RegularExpressions;

namespace BasicEssentials
{
    public class NormalizeString
    {
        public static string RemoveBlanks(string input)
        {
            return input.Trim().Replace(" ", "");
        }

        public static string RemoveSpaceStartIndex(string text)
        {
            Regex spaceStartStrign = new Regex(@"^$|\s+");

            if (spaceStartStrign.IsMatch(text) && !string.IsNullOrEmpty(text))
                return spaceStartStrign.Replace(text, "");
            else
                return text;
        }

    }
}
