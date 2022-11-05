using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.AdminPage.Clients;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage
{
    public class ClientPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha Foydalanuvchilar Ro'yxati");
            Console.WriteLine("2. Ma'lum Foydalanuvchi  ma'lumotlari");
            Console.WriteLine("3. Foydalanuvchi qo'shish");
            Console.WriteLine("4. Foydalanuvchi ma'lumotlarini tahrirlash");
            Console.WriteLine("5. Foydalanuvchini o'chirish");
            Console.WriteLine("6. Ortga");
            Console.WriteLine("7. Bosh sahifa");
            Console.WriteLine("8. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadAllPage.RunAsync();
            else if (selected == "2") await ReadPage.RunAsync();
            else if (selected == "3") await CreatePage.RunAsync();
            else if (selected == "4") await UpdatePage.RunAsync();
            else if (selected == "5") await DeletePage.RunAsync();
            else if (selected == "6") await AdminMainPage.RunAsync();
            else if (selected == "7") await MainPage.RunAsync();
            else if (selected == "8") return;

            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }

        }
    }
}
