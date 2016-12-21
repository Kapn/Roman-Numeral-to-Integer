using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rnumeral_CodeTest
{
    class Program
    {
        //simple dictionary<char, int> to store values of different Roman Numerals
        //Links Roman Numeral character to its associated value.
        private static Dictionary<char, int> romanDict = new Dictionary<char, int>
        {
           {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        
        //takes the user input string of Roman Numerals as input.
        //Calculated correct integer value and returns it.
        public static int romanNum_toInteger(string romanString)
        {
            int intValue = 0, prevValue = 0, nextValue = 0;

            for (int i = 0; i < romanString.Length; i++)
            {
                int curValue = romanDict[romanString[i]];
                if ((i + 1) <= (romanString.Length - 1))
                {
                    nextValue = romanDict[romanString[i + 1]];
                } else
                {
                    nextValue = 0;
                }
                
                if (nextValue > curValue)
                {
                    intValue += (nextValue - curValue);
                    i++;
                }else
                {
                    intValue += curValue;
                }
                prevValue = romanDict[romanString[i]];   
            }
            return intValue;
        }

        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("input 'quit' to quit");
            string readInString = "init";
            int integerValue = 0;

            //takes Roman Numeral user input until the user types 'quit'.
            while (!quit)
            {
                readInString = Console.ReadLine();
                //adjust user input to be lowercase, if the input is 'quit' then quit looping
                if (readInString.ToLower().Contains("quit"))
                {
                    quit = true;
                    break;
                }

                integerValue = romanNum_toInteger(readInString);
                Console.WriteLine(integerValue);
            }
        }
    }
}
