using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                

                if (i%3 == 0 && i%5 == 0)
                {
                    Console.Write(",Fizz Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.Write(",Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.Write(",Buzz");
                }
                else
                {
                    Console.Write("," + i);
                }
           
            }

            Console.ReadLine();

        }
    }
}
