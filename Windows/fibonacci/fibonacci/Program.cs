using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci
{
    class Program
    {


        static void Main(string[] args)
        {
            int fib1 = 0;
            int fib2 = 1;

            int fib = 0;

            while (fib <= 100)
            {
                fib = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib;

                if (isprime(fib))
                {
                    Console.WriteLine(fib);
                }

               
            }

            Console.ReadLine();

        }


        static bool isprime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;


        }



    }
}
