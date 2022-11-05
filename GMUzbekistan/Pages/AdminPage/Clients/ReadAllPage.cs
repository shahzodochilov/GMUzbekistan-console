using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System.Threading.Tasks;
using System;

namespace GMUzbekistan.Pages.AdminPage.Clients
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ClientPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
        public static async Task ShowDataAsync()
        {
            IClientRepository clientRepository = new ClientRepository();
            var clients = await clientRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Telefon raqami",
                "Yoshi", "Jinsi", "Manzili");

            foreach (var client in clients)
            {
                consoleTable.AddRow(client.Id, client.Name, client.PhoneNumber, client.Age, client.Gender.ToString(), client.Adress);
            }
            consoleTable.Write();
        }
    }
}
