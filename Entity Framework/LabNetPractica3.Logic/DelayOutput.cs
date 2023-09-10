using LabNetPractica3.Entities;
using LabNetPractica3.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabNetPractica3.UI
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
