using GMUzbekistan.Pages;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Helpers
{
    public class RoutingHelper
    {
        public static async Task MakeFooterAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Davom etasizmi?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Bosh sahifa      2. Chiqish");
            string selected = Console.ReadLine();
            if (selected == "1") await MainPage.RunAsync();
            else return;
        }
    }
}
