using GMUzbekistan.Helpers;
using GMUzbekistan.Pages.UserPage.Orders;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class OrderPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Buyurtma  ma'lumotlari");
            Console.WriteLine("2. Buyurtma qo'shish");
            Console.WriteLine("3. Buyurtmani tahrirlash");
            Console.WriteLine("4. Ortga");
            Console.WriteLine("5. Bosh sahifa");
            Console.WriteLine("6. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadPage.RunAsync();
            else if (selected == "2") await CreatePage.RunAsync();
            else if (selected == "3") await UpdatePage.RunAsync();
            else if (selected == "4") await UserMainPage.RunAsync();
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
