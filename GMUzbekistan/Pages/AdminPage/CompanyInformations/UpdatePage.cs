using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.CompanyInformations
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            CompanyInformation companyInformation = new CompanyInformation();
            Console.WriteLine("******   Kompaniya ma'lumotlarini o'zgartirish    ******");
            companyInformation.Id = 1;
            Console.Write("Name :  ");
            companyInformation.Name = Console.ReadLine();
            Console.Write("Telefon raqam :  ");
            companyInformation.PhoneNumber = Console.ReadLine();
            Console.Write("Telegram manzil :  ");
            companyInformation.TelegramAccount = Console.ReadLine();
            Console.Write("Pochta manzili:  ");
            companyInformation.Email = Console.ReadLine();
            Console.Write("Manzil :  ");
            companyInformation.Address = Console.ReadLine();

            ICompanyInformationRepository companyInformationRepository = new CompanyInformationRepository();
            bool created = await companyInformationRepository.UpdateAsync(1, companyInformation);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat o'zgartirildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Bosh sahifa.\n2. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await MainPage.RunAsync();
            else return;
        }
    }
}
