using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.UserPage.VacantPositions;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class VacantPositionPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha Vakantsiya Ro'yxati");
            Console.WriteLine("2. Ma'lum Vakantsiya  ma'lumotlari");
            Console.WriteLine("3. Ortga");
            Console.WriteLine("4. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadAllPage.RunAsync();
            else if (selected == "2") await ReadPage.RunAsync();
            else if (selected == "3") UserMainPage.RunAsync();
            else if (selected == "4") return;

            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }

        }
    }
}
