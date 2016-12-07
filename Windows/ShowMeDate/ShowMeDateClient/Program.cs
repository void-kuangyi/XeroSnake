using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeDateClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMeDateBusiness.ShowMeDateBusiness date = new ShowMeDateBusiness.ShowMeDateBusiness();
            Console.WriteLine(date.GetDate());
            Console.ReadLine();
        }
    }
}
