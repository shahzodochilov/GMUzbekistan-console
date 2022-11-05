using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.AdminPage;
using GMUzbekistan.Pages.AdminPage.CompanyInformations;
using GMUzbekistan.Pages.UserPage;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages
{
    public class MainPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Admin Panel");
            Console.WriteLine("2. User Panel");
            Console.WriteLine("3. Kompaniya haqida");
            Console.WriteLine("4. Chiqish");


        key:
            string selected = Console.ReadLine();
            if (selected == "1") await AdminCheckerPage.RunAsync();
            else if (selected == "2") await RegistrationPage.RunAsync();
            else if (selected == "3") await ReadPage.RunAsync();

            else if (selected == "4") return;
            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }
        }
    }
}
