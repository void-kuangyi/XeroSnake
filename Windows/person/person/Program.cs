using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace person
{
    class Program
    {
        static void Main(string[] args)
        {
            personBusinessLayer.personBusinessLayer reader = new personBusinessLayer.personBusinessLayer();

            Console.WriteLine(reader.read());

           // reader.Close();

            Console.ReadLine();

        }



    }

}
