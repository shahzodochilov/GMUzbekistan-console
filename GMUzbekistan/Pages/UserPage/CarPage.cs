using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.UserPage.Cars;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class CarPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha Avtomobillar Ro'yxati");
            Console.WriteLine("2. Ma'lum Avtomobil  ma'lumotlari");
            Console.WriteLine("3. Ortga");
            Console.WriteLine("4. Bosh sahifa");
            Console.WriteLine("5. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadAllPage.RunAsync();
            else if (selected == "2") await ReadPage.RunAsync();
            else if (selected == "3") await UserMainPage.RunAsync();
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
