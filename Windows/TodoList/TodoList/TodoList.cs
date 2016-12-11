using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TodoList
    {



        //private string Todo;
        private List<string> Todo = new List<string> ();

        public List<string> GetList()
        {
            return Todo;
        }


        public int WriteList(string input)
        {
            Todo.Add(input);
            return 0;
        }


    }
}
