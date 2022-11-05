using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Services;
using GMUzbekistan.Services;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Orders
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("--->>>   Buyurtma qilish!   <<<---");
            IOrderService orderService = new OrderService();
            bool created = await orderService.CreateAsync();
            if (created) StatusHelper.AcceptedMessage("Buyurtma Muvaffaqiyatli amalga oshirildi!");
            else StatusHelper.WrongMessage("Xatolik yuz berdi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await OrderPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
