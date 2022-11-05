using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Clients
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IClientRepository clientRepository = new ClientRepository();
            Console.Write("Mijoz Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await clientRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Foydalanuvchi muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Foydalanuvchi ma'lumotlarini o'chirib bo'lmadi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ClientPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
