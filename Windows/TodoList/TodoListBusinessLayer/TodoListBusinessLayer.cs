using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListBusinessLayer
{
    public class TodoListBusinessLayer
    {

        private TodoList.TodoList list;

        public TodoListBusinessLayer()
        {
            list = new TodoList.TodoList();
        }
        public string GetList()
        {
            return list.GetList();
        }

        public int WriteList(string input)
        {
            list.WriteList(input);
            return 0;
        }

        
    }
}
