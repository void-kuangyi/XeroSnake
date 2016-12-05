using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            int turn = 0;
            Random rnd = new Random();
            int num = rnd.Next(0, 100);

            Console.Write("Enter the input : ");

            while(true)
            {
                int input = int.Parse(Console.ReadLine());

                turn++;

                if (input == num)
                {
                    Console.WriteLine("your turn number is " + turn);
                    break;
                }
                if (input < num)
                {
                    Console.WriteLine("input is smaller than the number");
                }
                else
                {
                    Console.WriteLine("input is larger than the number");
                }

                
            }


            Console.ReadLine();



        }
    }
}
