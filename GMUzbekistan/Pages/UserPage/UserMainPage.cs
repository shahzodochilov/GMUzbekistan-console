using GMUzbekistan.Helpers;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class UserMainPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Foydalanuvchi");
            Console.WriteLine("2. Avtomobillar");
            Console.WriteLine("3. Buyurtmalar");
            Console.WriteLine("4. Vakant Lavozimlar");
            Console.WriteLine("5. Kompaniya xodimlari!");
            Console.WriteLine("6. Xabar qoldirish");
            Console.WriteLine("7. Ortga");
            Console.WriteLine("8. Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ClientPage.RunAsync();
            else if (selected == "2") await CarPage.RunAsync();
            else if (selected == "3") await OrderPage.RunAsync();
            else if (selected == "4") await VacantPositionPage.RunAsync();
            else if (selected == "5") await EmployeePage.RunAsync();
            else if (selected == "6") await ContactUsPage.RunAsync();
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
