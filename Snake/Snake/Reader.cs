using System;
using System.Threading;

namespace Snake
{
    // This class is used as a key listner. It waits for a few milliseconds for a key to be pressed.
    // Advantages of using this class: No busy waiting.

    // Modified version of: http://stackoverflow.com/questions/57615/how-to-add-a-timeout-to-console-readline
    class Reader
    {
        private static AutoResetEvent getInput, gotInput;
        private static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        static Reader()
        {
            getInput = new AutoResetEvent(false);
            gotInput = new AutoResetEvent(false);
            Thread inputThread = new Thread(reader);
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        private static void reader()
        {
            while (true)
            {
                getInput.WaitOne();
                keyInfo = Console.ReadKey();
                gotInput.Set();
            }
        }

        public static ConsoleKeyInfo ReadKey(int timeOutMillisecs)
        {
            getInput.Set();
            gotInput.WaitOne(timeOutMillisecs);
            return keyInfo;
        }
    }
}
