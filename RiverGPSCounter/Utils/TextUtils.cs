using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RiverGPSCounter.Utils
{
    public class TextUtils
    {
        public static string ToAscii(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);

            // Použití regulárního výrazu k nalezení a nahrazení všech znaků mimo základní ASCII rozsah
            // Toto odstraní speciální znaky a zachová pouze základní písmena a číslice
            string regex = @"[^a-zA-Z0-9\s]";
            string cleanString = Regex.Replace(normalizedString, regex, "");

            return cleanString;
        }

        public static void ToUtf8(string inputFile, string outputFile)
        {
            using (StreamReader reader = new StreamReader(inputFile, Encoding.Unicode))
            {
                using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
                {
                    CopyContents(reader, writer);
                }
            }
        }

        static void CopyContents(TextReader input, TextWriter output)
        {
            char[] buffer = new char[8192];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, len);
            }
        }


    }
}
