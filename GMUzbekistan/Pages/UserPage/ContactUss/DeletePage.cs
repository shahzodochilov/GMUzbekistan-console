using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.ContactUss
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IContactUsRepository contactUsRepository = new ContactUsRepository();
            Console.Write("Xabar Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await contactUsRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Xabar muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Xabarni o'chirib bo'lmadi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ContactUsPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
