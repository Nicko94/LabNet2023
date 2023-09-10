using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using LabNetPractica3.Logic;
using LabNetPractica3.Entities;

namespace LabNetPractica3.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelayOutput delay = new DelayOutput();
            MenuLogic menu = new MenuLogic();

            while (!menu.GetExitValue())
            {
                menu.ExecuteMenu();
            }
        }
    }
}
