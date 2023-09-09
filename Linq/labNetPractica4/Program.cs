using LabNetPractica4.UI;

namespace labNetPractica4.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuLogic Menu = new MenuLogic();

            while (!Menu.GetExitValue())
            {
                Menu.ExecuteMenu();
            }
        }
    }
}
