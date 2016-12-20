using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rnumeral_CodeTest
{
    class Program
    {
        private static Dictionary<char, int> romanDict = new Dictionary<char, int>
        {
           {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        public static int romanNum_toInteger(string romanString)
        {
            int intValue = 0;
            Console.WriteLine(romanDict[romanString[0]]);
            //for(int i = 0; i < romanString.Length; i++)
            //{

            //}


            return intValue;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("input 'quit' to quit");
            string readInString = Console.ReadLine();
            while(readInString != "quit")
            {
                readInString = Console.ReadLine();
                romanNum_toInteger(readInString);
                Console.WriteLine("heloooo world");
            }
            
        }


    }
}
