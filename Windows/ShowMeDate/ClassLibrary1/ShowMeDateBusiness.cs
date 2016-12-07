using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeDateBusiness
{
    public class ShowMeDateBusiness
    {
        public string GetDate()
        {
            ShowMeDateDataLayer.ShowMeDateDataLayer date = new ShowMeDateDataLayer.ShowMeDateDataLayer();
            return date.GetDate();
        }
    }
}
