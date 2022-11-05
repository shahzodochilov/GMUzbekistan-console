using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.CompanyInformations
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            ICompanyInformationRepository companyInformationRepository = new CompanyInformationRepository();
            Console.WriteLine("Kompaniya haqida ma'lumot: ");
            var item = await companyInformationRepository.GetAsync(1);

            ConsoleTable consoleTable = new ConsoleTable("Nomi", "Telefon raqami", "Telegram manzili", "Pochta manzili", "Manzili");
            consoleTable.AddRow(item.Name, item.PhoneNumber, item.TelegramAccount, item.Email, item.Address);
            consoleTable.Write();

            Console.WriteLine("1. Bosh sahifa.\n2. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await MainPage.RunAsync();
            else return;
        }
    }
}
