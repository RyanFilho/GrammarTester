using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarTester
{
    class Program
    {
        private static List<string> rules;

        static void Main(string[] args)
        {
            rules = new List<string>() { "SA", "SB", "AAx", "AyB", "BAB", "BBz", "Bz" };
            var input = "z";
            var word = "S";

            if (test(input, word))
            {
                Console.WriteLine("Entrada correta.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Entrada incorreta.");
                Console.ReadKey();
            }
        }

        private static bool test(string input, string word)
        {
            char stateRecurse = '\0';
            
            if (word.Equals(input))
                return true;

            if (word.Length > input.Length)
                return false;

            stateRecurse = word.First(x => char.ToUpper(x) == x);

            if (stateRecurse == '\0')
                return false;

            foreach (var x in rules){

                if (x.ElementAt(0).Equals(stateRecurse))
                {
                    word = word.Replace(stateRecurse.ToString(), x.Remove(0,1)).ToString();

                    if (test(input, word))
                        return true;
                }
            }

            return false;
        }
    }
}