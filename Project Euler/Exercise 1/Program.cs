using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 3.\nGet prime factor of 600851475143.");
            Console.WriteLine("Largest prime factor number?");
            string input = Console.ReadLine();
            long maxNumber;
            Int64.TryParse(input, out maxNumber);

            long largestPrimeFactor = FindLargestPrimeFactor(maxNumber);

            Console.WriteLine(largestPrimeFactor);

            Console.ReadLine();

        }

        public static long FindLargestPrimeFactor(long dividend)
        {
            //List<long> primeNumbers = GetPrimeNumbers(dividend); //commented out as not optimal nor efficient
            long largestPrimeFactor = 0;
            long quotient = 0;

            
            do //loop while the quotient is not prime
            {
                //foreach (var number in primeNumbers) //my first loop - inefficient as you dont need to get all possible primes before hand.
                for (long i = 2; i < dividend; i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        quotient = dividend / i;

                        if (dividend % i == 0) //if it is divisible, we do something, if not we try another prime number as a divisor.
                        {

                            if (IsPrimeNumber(quotient)) //  is the quotient a prime number, if yes end, because thats what we are looking for.
                            {
                                Console.WriteLine($" prime factor divisor for dividend {dividend} is {i} with {quotient} as PRIME quotient.");
                                largestPrimeFactor = quotient;
                                break;
                            }
                            else//quotient not a prime number,
                            {
                                Console.WriteLine($" prime factor divisor for dividend {dividend} is {i} with {quotient} as quotient.");
                                dividend = quotient; //make the quotient the new dividend and we try to find a prime factor divisor for that dividend.
                                break;
                            }
                        }
                    }

                }
            } while (!IsPrimeNumber(quotient));

            return largestPrimeFactor;
        }

        public static bool IsPrimeNumber(long number)
        {
            if (number <= 1) //cannot divide by zero, and everything is divisible by 1.
                return false;

            for (long divisor = 2; divisor <= number; divisor++)
            {

                if (number % divisor == 0 && number != divisor) //check if it is divisible - but exlucde self divisibility.
                {
                    return false;
                }
                else
                {
                    //find max divisor - we can eliminate anything higher than the quotient.
                    decimal quotient = (decimal)number / (decimal)divisor;
                    long maxDivisor = (long)Math.Ceiling(quotient);

                    if (maxDivisor <= divisor)//end of the loop - no divisible natural number - its a prime.
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static List<long> GetPrimeNumbers(long maxNumber) //initial solution - this was SLOW - generates a list of prime numbers - limited by max List Length.
        {
            List<long> primeNumbers = new List<long>();

            for (long i = 2; i < maxNumber; i++)
            {

                if (i == 2) //auto add the lowest possible number
                {
                    primeNumbers.Add(i);
                    continue;
                }

                //this loop below was extracted to a method IsPrimeNumber
                //We could have replaced this loop with the method, but i left it here for reference so we can see my initial code for finding primes.
                long maxDivisor = i; //just to make it more readable.
                for (long n = 2; n < maxDivisor; n++)//using less than we exlude the possibility of divding by itself.
                {

                    if (maxDivisor <= 1) //cannot divide by zero, and everything is divisible by 1.
                        break;


                    if (i % n == 0 && i != n) // is divisible by a natural number, therefore not a prime.
                    {
                        break;
                    }
                    else
                    {
                        //Adjust maxDivisor - so that the loop no longer needs to reach max divisor. 
                        //Since We already eliminated the possibility of other numbers higher than the quotient as possible divisor
                        decimal number = (decimal)i / (decimal)n;
                        long newMax = (long)Math.Ceiling(number);

                        if (newMax <= n && newMax != 0)//end of the loop - no divisible natural number - its a prime.
                        {
                            primeNumbers.Add(i);
                            break;
                        }
                    }
                }
            }

            return primeNumbers;
        }


        public static List<long>  GetPrimNumbersEratosthenesAlgorithm(long number)
        {
            bool[] numbersCollection = new bool[number];
            List<long> primeCollection = new List<long>();
            numbersCollection[0] = false; // already known no prime - so we eliminate it before hand.
            numbersCollection[1] = false;

            //assume all numbers are prime - excluding 0 & 1
            for (long i = 2; i < number; i++)
            {
                numbersCollection[i] = true;
            }

            for (long i = 0; i < number; i++)
            {
                if (numbersCollection[i])
                {
                    primeCollection.Add(i);
                    for (long j = 2; j * i <= Math.Sqrt(number); j++)
                    {
                        numbersCollection[i * j] = false;
                    }
                }

            }

            //return primeNumbers;
            return primeCollection;

        }

    }


}
