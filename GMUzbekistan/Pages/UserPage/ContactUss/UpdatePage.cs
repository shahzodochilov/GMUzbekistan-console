using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using GMUzbekistan.Security;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.ContactUss
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            IContactUsRepository contactUsRepository = new ContactUsRepository();
            ContactUs contactUs = new ContactUs();
            Console.WriteLine("******   Xabarni tahrirlash    ******");
            Console.Write("Id ni kiriting : ");
            int id = int.Parse(Console.ReadLine());
            contactUs.Id = id;
            Console.Write("Ismingizni kiriting :  ");
            contactUs.UserName = Console.ReadLine();
            Console.Write("Telefon raqam :  ");
            contactUs.PhoneNumber = Console.ReadLine();
            Console.Write("Elektron pochta :  ");
            contactUs.UserEmail = Console.ReadLine();
            Console.Write("Mavzu :  ");
            contactUs.Theme = Console.ReadLine();
            Console.Write("Xabar matnini kiriting  :   ");
            contactUs.Message = EncryptMessage.EncryptString(Console.ReadLine());

            bool created = await contactUsRepository.UpdateAsync(id, contactUs);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat O'zgartirildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ContactUsPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
