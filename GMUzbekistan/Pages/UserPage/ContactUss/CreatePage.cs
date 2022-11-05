using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using GMUzbekistan.Security;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.ContactUss
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            IContactUsRepository contactUsRepository = new ContactUsRepository();
            ContactUs contactUs = new ContactUs();
            Console.WriteLine("******   Yangi Xabar qo'shish    ******");
            contactUs.Id = (await contactUsRepository.GetAllAsync()).OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            Console.Write("Ismingizni kiriting :  ");
            contactUs.UserName = Console.ReadLine();
            Console.Write("Telefon raqam :  ");
            contactUs.PhoneNumber = Console.ReadLine();
            Console.Write("Elektron pochta :  ");
            contactUs.UserEmail = Console.ReadLine();
            Console.Write("Mavzu :  ");
            contactUs.Theme = Console.ReadLine();
            Console.Write("Xabar matnini kiriting  :   ");
            string message = Console.ReadLine();
            contactUs.Message = EncryptMessage.EncryptString(message);

            bool created = await contactUsRepository.CreateAsync(contactUs);
            if (created) StatusHelper.InfoMessage($"Hurmatli {contactUs.UserName} sizning Id ingiz -> {contactUs.Id}  bu sizga keyinchalik ma'lumotlarni " +
                $"qayta tahrirlashda kerak bo'lishi mumkin!");
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat qo'shildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ContactUsPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
