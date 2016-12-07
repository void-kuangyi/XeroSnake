using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldBusinessLayer
{
    public class HelloWorldBusinessLayer
    {
        public string getHelloWorld()
        {
            HelloWorldDataLayer.HelloWorldDataLayer database = new HelloWorldDataLayer.HelloWorldDataLayer();
            string HelloWorldText = database.GetHelloWorld();
            return HelloWorldText;
        }
        
    }
}
