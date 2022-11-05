using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.AdminPage.ContactUss;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage
{
    public class ContactUsPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha Xabarlar Ro'yxati");
            Console.WriteLine("2. Ma'lum Xabar  ma'lumotlari");
            Console.WriteLine("3. Xabarni o'chirish");
            Console.WriteLine("4. Ortga");
            Console.WriteLine("5. Bosh sahifa");
            Console.WriteLine("6. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadAllPage.RunAsync();
            else if (selected == "2") await ReadPage.RunAsync();
            else if (selected == "3") await DeletePage.RunAsync();
            else if (selected == "4") await AdminMainPage.RunAsync();
            else if (selected == "5") await MainPage.RunAsync();
            else if (selected == "6") return;

            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }

        }
    }
}
