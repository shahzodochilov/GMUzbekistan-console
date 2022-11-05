using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Orders
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IOrderRepository orderRepository = new OrderRepository();
            Console.Write("Buyurtma Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await orderRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("O'chirib bo'lmadi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await OrderPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
