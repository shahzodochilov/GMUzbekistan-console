using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Services;
using GMUzbekistan.Services;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Orders
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("--->>>   Buyurtmani tahrirlash!   <<<---");
            Console.Write("Buyurtma Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());
            IOrderService orderService = new OrderService();
            bool updated = await orderService.UpdateAsync(id);
            if (updated) StatusHelper.AcceptedMessage("Buyurtma Muvaffaqiyatli tahrirlandi!");
            else StatusHelper.WrongMessage("Xatolik yuz berdi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await OrderPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
