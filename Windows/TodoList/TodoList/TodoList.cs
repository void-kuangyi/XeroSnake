using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TodoList
    {
        public string GetList()
        {
            string list = System.IO.File.ReadAllText(@"C:\Code\Windows\TodoList\TodoList.txt");
            return list;
        }
    }
}
