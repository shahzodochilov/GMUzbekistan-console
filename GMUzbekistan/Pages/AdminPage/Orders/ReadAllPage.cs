using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Services;
using GMUzbekistan.Services;
using System.Threading.Tasks;
using System;

namespace GMUzbekistan.Pages.AdminPage.Orders
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            IOrderService orderService = new OrderService();

            var orderViewModels = await orderService.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Xaridor", "Summa", "Avtomobil Nomi", "Status", "Zakaz vaqti");

            foreach (var orderViewModel in orderViewModels)
            {
                string purchaseStatus;
                if (orderViewModel.PurchaseStatus == Enums.OrderPurchaseStatus.New) purchaseStatus = "Yangi";
                else if (orderViewModel.PurchaseStatus == Enums.OrderPurchaseStatus.StandbyMode) purchaseStatus = "To'lov Jarayonida";
                else purchaseStatus = "To'lov qilingan";

                consoleTable.AddRow(orderViewModel.Id, orderViewModel.ClientName, orderViewModel.Amount, orderViewModel.CarName, purchaseStatus, orderViewModel.Date.ToString("dd/MM/yy HH:mm"));
            }
            consoleTable.Write();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await OrderPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
