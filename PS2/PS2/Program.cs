using System;

namespace PS2
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            int n = -1;
            int k = -1;

            // Throw away the parsing of k and n.  They do not contribute to the algorithm at all
            line = Console.ReadLine();
            int whitespaceIndex = line.IndexOf(" ");
            string n_Unparsed = line.Substring(0, whitespaceIndex);
            string k_Unparsed = line.Substring(whitespaceIndex + 1, line.Length - whitespaceIndex - 1);
            n = int.Parse(n_Unparsed);
            k = int.Parse(k_Unparsed);
        }
    }
}
