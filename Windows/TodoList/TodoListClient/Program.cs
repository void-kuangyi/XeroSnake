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
            // TodoListBusinessLayer.TodoListBusinessLayer list = new TodoListBusinessLayer.TodoListBusinessLayer();
            // Console.WriteLine(list.GetList());

            //  enum action {read = 0, write = 1};
            Console.WriteLine("Enter write/read/quit to write and read your todo list and quit the program");
            TodoListBusinessLayer.TodoListBusinessLayer Todo = new TodoListBusinessLayer.TodoListBusinessLayer();

            while (true)
            {
                Console.Write(">");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "write":
                        Console.Write("Enter your todo list :");
                        string input = Console.ReadLine();
                        Todo.WriteList(input);
                        break;

                    case "read":
                        Todo.GetList().ForEach(Console.WriteLine);
                        break;

                    default:
                        break;
                }

                if (action == "quit")
                {
                    break;
                }
            }


        }
    }
}

