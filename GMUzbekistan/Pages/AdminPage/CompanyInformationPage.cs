using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.AdminPage.CompanyInformations;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage
{
    public class CompanyInformationPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Hozirgi ma'lumotlarni ko'rish");
            Console.WriteLine("2. Ma'lumotlarini o'zgartirish");
            Console.WriteLine("3. Ortga");
            Console.WriteLine("4. Bosh sahifa");
            Console.WriteLine("5. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadPage.RunAsync();
            else if (selected == "2") await UpdatePage.RunAsync();
            else if (selected == "3") await MainPage.RunAsync();
            else if (selected == "4") await MainPage.RunAsync();
            else if (selected == "5") return;


            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }

        }
    }
}
