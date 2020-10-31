using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What prime do  you want?");
            int input = int.Parse(Console.ReadLine());
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(FindPrimes(input));
            watch.Stop();
            Console.WriteLine($"The original FindPrimes took {watch.ElapsedMilliseconds} to compute for input {input}");
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(FindPrimes2(input));
            watch2.Stop();
            Console.WriteLine($"The new FindPrimes took {watch2.ElapsedMilliseconds} to compute for input {input}");
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(FindPrimes3(input));
            watch3.Stop();
            Console.WriteLine($"The newest FindPrimes took {watch3.ElapsedMilliseconds} to compute for input {input}");

            Console.ReadLine();
        }
         //First version of FindPrimes. Literally just loops over every number less than or equal to the number
         //being looked at, then sees how many divisors it has. If it has two, then the number is a prime and you 
         //can increase the number of primes found. It will continue to find primes until the number of primes
         //reaches the initial prime index you requested.
        static int FindPrimes(int index)
        {
            int primeCount = 0;
            int divisors = 0;
            int num = 0;                
            while(primeCount < index)
            {
                num++;
                divisors = 0;
               for(int i = 1; i <=num; i++)
                {
                    if(num%i == 0)
                    {
                        divisors++;
                    }
                }
               if(divisors == 2)
                {
                    primeCount++;
                    
                }
            }
            return num;
        }
        /* A more efficient version of FindPrimes called FindPrimes2. This uses a while loop instead of a for loop,
         * and it will stop looking at the current number in question if the number of divisors exceeds 2, because
         * that means for sure it's not a prime number. It knows a prime number has been found when i, the current 
         *iteration number, is equal to the number in question (meaning only one and itself are divisors) and that if
         *the number of divisors are 2. */
        static int FindPrimes2(int index)
        {
            int primeCount = 0;
            int divisors = 0;
            int num = 0;
            while (primeCount < index)
            {
                num++;
                divisors = 0;
                int i = 1;
                while( i <= num && divisors <=2)
                {
                    if (num % i == 0)
                    {
                        divisors++;
                    }
                    i++;
                }
                if (i-1 == num && divisors == 2)
                {
                    primeCount++;
                }

            }
            return num;
        }
        /* An even more efficient method called FindPrimes3. Here, it is based on the fact that divisors
         * come in pairs, and you only need to iterate up to sqrt(num) in order to find all divisors.*/

        static int FindPrimes3(int index)
        {
            int primeCount = 0;
            int divisors = 0;
            int num = 0;
            while (primeCount <= index)
            {
                num++;
                divisors = 0;
                int i = 1;
                while (i <= Math.Sqrt(num) && divisors <= 2)
                {
                    if (num % i == 0)
                    {
                        divisors +=2;
                    }
                    i++;
                }
                if (i - 1 == Math.Floor(Math.Sqrt(num)) && divisors == 2)
                {
                    primeCount++;
                }

            }
            return num;
        }
    }
}
