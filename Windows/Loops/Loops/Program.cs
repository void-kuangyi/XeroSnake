using system;
using system.collections.generic;
using system.linq;
using system.text;
using system.threading.tasks;

namespace loops
{
    class program
    {
        static void main(string[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 != 0)
                {
                    console.writeline(i);
                }
            }

            console.readline();
            
        }
    }
}
