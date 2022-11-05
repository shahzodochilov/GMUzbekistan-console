using GMUzbekistan.Pages.UserPage.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class RegistrationPage
    {
        public static async Task RunAsync() 
        {
            Console.Clear();
            Console.WriteLine("1. Ro'yxatdan o'tish");
            Console.WriteLine("2. Kirish");
            Console.WriteLine("3. Ortga");
            Console.WriteLine("4. Chiqish");

            string temp = Console.ReadLine();
            if (temp == "1") await CreatePage.RunAsync();
            else if (temp == "2") await UserCheckerPage.RunAsync();
            else if (temp == "3") await MainPage.RunAsync();
            else return;

        }
    }
}
