using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldBusinessLayer.HelloWorldBusinessLayer businessHelloWorld = new HelloWorldBusinessLayer.HelloWorldBusinessLayer();

            string helloWorldText = businessHelloWorld.getHelloWorld();
            Console.WriteLine(helloWorldText);

            Console.ReadKey();

        }
    }
}
