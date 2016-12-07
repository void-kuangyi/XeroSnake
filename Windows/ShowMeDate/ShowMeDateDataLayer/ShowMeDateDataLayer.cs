using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeDateDataLayer
{
    public class ShowMeDateDataLayer
    {
        public string GetDate()
        {
            String today = DateTime.Today.ToShortDateString();
            return today;
        }
    }
}
