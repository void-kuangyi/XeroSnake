using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListBusinessLayer
{
    public class TodoListBusinessLayer
    {
        public string GetList()
        {
            TodoList.TodoList list = new TodoList.TodoList();
            return list.GetList();
        }
    }
}
