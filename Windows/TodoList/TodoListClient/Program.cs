using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoListBusinessLayer.TodoListBusinessLayer list = new TodoListBusinessLayer.TodoListBusinessLayer();
            Console.WriteLine(list.GetList());
            Console.ReadLine();

        }
    }
}
