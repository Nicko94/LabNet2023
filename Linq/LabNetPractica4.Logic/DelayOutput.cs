using System;
using System.Threading;

namespace LabNetPractica4.UI
{
    public class DelayOutput
    {
        public void TextDelay(string text)
        {
            Thread.Sleep(50);
            Console.WriteLine(text);
        }

        public void ListDelay(string text)
        {
            Thread.Sleep(20);
            Console.WriteLine(text);
        }
    }
}
