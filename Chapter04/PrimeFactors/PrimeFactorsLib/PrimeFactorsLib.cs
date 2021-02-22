using System;
using System.Linq;
using System.Collections.Generic;

namespace PrimeFactorsLib
{
    public class PrimeFactorGenerator
    {
        public static string PrimeFactors(int num)
        {
            List<int> primeFactors = new List<int>();

            //take out the 2's
            while (num % 2 == 0)
            {
                primeFactors.Add(2);
                num /= 2;
            }

            //take out the primes.
            int factor = 3;
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    //this is a factor.
                    primeFactors.Add(factor);
                    num /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    factor += 2;
                }
            }
                //If num is not 1, then whatever is left is prime.
                if (num > 1)
                {
                    primeFactors.Add(num);
                }

                string returnString = String.Empty;
                foreach (int n in primeFactors)
                {
                    returnString += n.ToString() + " ";
                }

                returnString = returnString.Trim();
                return returnString;
        }
    }
}
