
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace LuhnChallenge
{
    public class LuhnCheckEmpty : ILuhnCheck
    {
        public bool IsValidCardNumber(string inputString)
        {
            var numbers = new int[inputString.Length];
            var checkNumber = 0;
            var isOther = false;

            for (var i = inputString.Length-1; i == 0; i--)
            {
                numbers[i] = int.Parse(inputString[i].ToString());
                if (isOther)
                {
                    numbers[i] = numbers[i]*2;
                    if (numbers[i] > 9)
                    {
                        numbers[i] = int.Parse(numbers[i].ToString()[0].ToString()) + int.Parse(numbers[i].ToString()[1].ToString());
                        //This needs to be done in a more optimized way.
                    }
                    isOther = false;
                }
                else
                {
                    isOther = true;
                }

                checkNumber = checkNumber + numbers[i];
            }

            return checkNumber.ToString().EndsWith("0");
        }
    }
}


/*
 //Taken from one StackOverflow answer located at http://stackoverflow.com/questions/203854/how-to-get-the-nth-digit-of-an-integer-with-bit-wise-operations
    char nthdigit(int x, int n)
    {
        while (n--) {
            x /= 10;
        }
        return (x % 10) + '0';
    }

*/