using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: Nate Stephens
///     Challenge Name: Roman Numeral Conversion
///     Challenge #: 189
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/2ms946/20141119_challenge_189_intermediate_roman_numeral/
///     Brief Description of Challenge:
///     Input some numbers and return roman numerals, and also input roman numerals and return base-10 numbers.
/// 
///
///     What was difficult about this challenge?
///     Figuring out how to relate the the Roman Numeral with its numerical value.  Used an Enumerable and a string array.
///
///     
///
///     What was easier than expected about this challenge?
///     How to actually make the conversion once i figured out the enum and string array.
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.

namespace DailyProgrammer_Template
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Simple function to illustrate how to use tests
        /// </summary>
        /// <param name="inputInteger"></param>
        /// <returns></returns>
        public static int MyTestFunction(int inputInteger)
        {
            return inputInteger;
        }
    }

    class RomanNumeralConverter
    {
        public enum RomNum
        {
            I = 1,
            IV = 4,
            V = 5,
            IX = 9,
            X = 10,
            XL = 40,
            L = 50,
            XC = 90,
            C = 100,
            CD = 400,
            D = 500,
            CM = 900,
            M = 1000
        }

        public string[,] intAndRom = new string[,]
        {
            {"M", "1000"},
            {"CM", "900"},
            {"D", "500"},
            {"CD", "400"},
            {"C", "100"},
            {"XC", "90"},
            {"L", "50"},
            {"XL", "40"},
            {"X", "10"},
            {"IX", "9"},
            {"V", "5"},
            {"IV", "4"},
            {"I", "1"},
        };

        public RomanNumeralConverter() { }

        public int RomanToNumber(string romanNum)
        {
            //int test = (int)((RomNum)Enum.Parse(typeof(RomNum), romanNum[0].ToString()));
            int returnedNumber = 0;
            for (int i = 0; i < romanNum.Length; i++)
            {
                if (i < romanNum.Length -1 &&(((int)((RomNum)Enum.Parse(typeof(RomNum), romanNum[i].ToString()))) < ((int)((RomNum)Enum.Parse(typeof(RomNum), romanNum[i + 1].ToString())))))
                {
                    returnedNumber -= (int)((RomNum)Enum.Parse(typeof(RomNum), romanNum[i].ToString()));
                }
                else
                {
                    returnedNumber += (int)((RomNum)Enum.Parse(typeof(RomNum), romanNum[i].ToString()));
                }
            }
            return returnedNumber;
        }

        public string NumberToRoman(int intNum)
        {
            string returnedRoman = string.Empty;
            for (int i = 0; i < intAndRom.Length/2; i++)
            {
                while (intNum - (int.Parse(intAndRom[i, 1])) >= 0)
                {
                    intNum -= int.Parse(intAndRom[i, 1]);
                    returnedRoman += intAndRom[i, 0];
                }
            }
            return returnedRoman;
        }
    }


#region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        RomanNumeralConverter testObject = new RomanNumeralConverter();
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidTest()
        {
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            int result = testObject.RomanToNumber("MCMLXXXIII");  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result == 1983, "This is the message that displays if it does not pass");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTest()
        {
            string result = testObject.NumberToRoman(1983);
            Assert.IsFalse(result == "MCMLXXXII");
        }
    }
#endregion
}
