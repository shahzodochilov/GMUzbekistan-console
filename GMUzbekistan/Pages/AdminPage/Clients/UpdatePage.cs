using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using GMUzbekistan.Security;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Clients
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Client client = new Client();
            Console.WriteLine("******   Foydalanuvchi ma'lumotlarini yangilash   ******");
            Console.WriteLine("Id sini kiriting :  ");
            int id = int.Parse(Console.ReadLine());
            client.Id = id;
            Console.Write("Ism :  ");
            client.Name = Console.ReadLine();
            Console.Write("Telefon raqam :  ");
            client.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Jins tanlang! \n1. Erkak  2. Ayol ");
            int selected = int.Parse(Console.ReadLine());
            client.Gender = (Enums.Gender)selected;
            Console.WriteLine("Yoshi :  ");
            client.Age = byte.Parse(Console.ReadLine());
            Console.Write("Parol kiriting :  ");
            string pass = Console.ReadLine();
            client.Pass = Hasher.HashString(pass, client.Id.ToString());
            Console.Write("Manzil :  ");
            client.Adress = Console.ReadLine();

            IClientRepository clientrepository = new ClientRepository();
            bool created = await clientrepository.UpdateAsync(id, client);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat O'zgartirildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await ClientPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
