using System;
using System.Threading;

namespace Snake
{
    // This class is used as a key listner. It waits for a few milliseconds for a key to be pressed.
    // Advantages of using this class: No busy waiting.

    // Modified version of: http://stackoverflow.com/questions/57615/how-to-add-a-timeout-to-console-readline
    internal class KeyListner
    {
        private AutoResetEvent waitForInputEvent;
        private AutoResetEvent gotInputEvent;
        private static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        public KeyListner()
        {
            waitForInputEvent = new AutoResetEvent(false);
            gotInputEvent = new AutoResetEvent(false);
            Thread inputThread = new Thread(KeyReader);
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        private void KeyReader()
        {
            while (true)
            {
                waitForInputEvent.WaitOne();
                keyInfo = Console.ReadKey();
                gotInputEvent.Set();
            }
        }

        public ConsoleKeyInfo ReadKey(int timeOutMillisecs)
        {
            waitForInputEvent.Set(); // Set() is a method in the EventWaitHandle library. Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
            gotInputEvent.WaitOne(timeOutMillisecs);
            return keyInfo;
        }
    }
}
