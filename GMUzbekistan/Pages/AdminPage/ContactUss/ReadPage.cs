using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using GMUzbekistan.Security;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.ContactUss
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ContactUsPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
        public static async Task ShowDataAsync()
        {
            IContactUsRepository contactUsRepository = new ContactUsRepository();
            Console.WriteLine("--->    Id ingizni kiriting!    <---");
            int id = int.Parse(Console.ReadLine());
            var contactUs = await contactUsRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Foydalanuvchi", "Telefon raqami",
                "Elektron Pochtasi", "Mavzu", "Xabar");

            consoleTable.AddRow(contactUs.Id, contactUs.UserName, contactUs.PhoneNumber, contactUs.UserEmail, contactUs.Theme, DecryptMessage.DecryptString(contactUs.Message));


            consoleTable.Write();
        }
    }
}
