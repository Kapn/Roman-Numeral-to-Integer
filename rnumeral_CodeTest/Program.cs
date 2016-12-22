using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rnumeral_CodeTest
{
    public class Program
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
            int intValue = 0, prevValue = -2, nextValue = -1, curValue = 0, highestValue = 0;            

            //check if string is longer than 15 characters, MMMDCCCLXXXVIII is longest possible numeral.
            if (romanString.Length > 15)
            {
                Console.WriteLine("Error, largest roman numeral is only 15 characters");
                return -1;
            }

            //loop through each character of romanString
            for (int i = 0; i < romanString.Length; i++)
            {
                //check if more than 3 of the same numerals are in a row
                if ((i + 3) <= (romanString.Length - 1))
                {
                    if (romanDict[romanString[i]] == romanDict[romanString[i + 1]] && romanDict[romanString[i]] == romanDict[romanString[i + 2]])
                    {
                        if (romanDict[romanString[i]] == romanDict[romanString[i + 3]])
                        {
                            Console.WriteLine("Error, can only be 3 of the same numerals in a row");
                            return -1;
                        }
                    }
                }
                //verify that the key exists in the dict.
                //set curValue if exists.
                if (romanDict.ContainsKey(romanString[i]))
                {
                    curValue = romanDict[romanString[i]];
                } else
                {
                    Console.WriteLine("Incorrect Input: " + romanString[i]);
                    return -1;
                }

                //verify that the next key exists in the dict
                //set nextValue if exists.
                if ((i + 1) <= (romanString.Length - 1))
                {
                    if (romanDict.ContainsKey(romanString[i + 1]))
                    {
                        nextValue = romanDict[romanString[i + 1]];
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input: " + romanString[i + 1]);
                        return -1;
                    }
                } else
                {
                    nextValue = 0;
                }

                //check if incorrect use of roman numerals was used
                //i.e: VV instead of X
                if (curValue == nextValue)
                {
                    switch (nextValue)
                    {
                        case 5:
                            {
                                Console.WriteLine("Error, Used 'VV' when could have used 'X'");
                                return -1;
                            }
                        case 50:
                            {
                                Console.WriteLine("Error, Used 'LL' when could have used 'C'");
                                return -1;
                            }
                        case 500:
                            {
                                Console.WriteLine("Error, Used 'DD' when could have used 'M'");
                                return -1;
                            }
                    }
                }
                //check whether correct subtraction is used
                if (nextValue > curValue)
                {
                    //check whether we are adding and then subtracting the same character
                    if (((i + 2) <= romanString.Length - 1))
                    {
                        if (romanDict[romanString[i + 2]] == curValue)
                        {
                            Console.WriteLine("Error, subtracting a value, then adding it again");
                        }
                    }
                    //insure correct values are used for subtraction, only I,X,and C are used for subtraction
                    if (curValue == 100 || curValue == 10 || curValue == 1)
                    {
                        intValue += (nextValue - curValue);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Error, can only subtract using I, X, or C. Re-order string");
                        return -1;
                    }

                } else
                {
                    intValue += curValue;
                }                            

                //save prevValue for future iterations
                prevValue = curValue;   
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
                readInString = readInString.ToUpper();
                //adjust user input to be lowercase, if the input is 'quit' then quit looping
                if (readInString.Contains("QUIT"))
                {
                    quit = true;
                    break;
                }

                integerValue = romanNum_toInteger(readInString);

                if (integerValue > -1)
                    Console.WriteLine(integerValue);                
            }
        }
    }
}
