using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personBusinessLayer
{
    public class personBusinessLayer
    {
        public string read()
        {
            personDataLayer.personDataLayer reader = new personDataLayer.personDataLayer();

            return reader.read();
            

        }
    }
}
