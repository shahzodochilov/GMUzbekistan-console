using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.UserPage.ContactUss;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class ContactUsPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Xabar qoldirish");
            Console.WriteLine("2. Xabaringiz  ma'lumotlari");
            Console.WriteLine("3. Xabarni tahrirlash");
            Console.WriteLine("4. Xabarni o'chirish");
            Console.WriteLine("5. Ortga");
            Console.WriteLine("6. Bosh sahifa");
            Console.WriteLine("7. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await CreatePage.RunAsync();
            else if (selected == "2") await ReadPage.RunAsync();
            else if (selected == "3") await UpdatePage.RunAsync();
            else if (selected == "4") await DeletePage.RunAsync();
            else if (selected == "5") await UserMainPage.RunAsync();
            else if (selected == "6") await MainPage.RunAsync();
            else if (selected == "7") return;

            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }

        }
    }
}
