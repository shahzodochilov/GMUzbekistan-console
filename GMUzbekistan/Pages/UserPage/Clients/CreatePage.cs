using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using GMUzbekistan.Security;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.Clients
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Client client = new Client();
            IClientRepository clientrepository = new ClientRepository();
            Console.WriteLine("******   Registratsiyadan o'tish    ******");

            client.Id = (await clientrepository.GetAllAsync()).OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
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

            
            bool created = await clientrepository.CreateAsync(client);
            if (created) StatusHelper.AcceptedMessage($"Muvaffaqiyatli yakunlandi!\nHurmatli mijoz Sizning Id ingiz : {client.Id}.\n" +
                    $"Bu sizga Tizimga qayta kirish uchun kerak bo'ladi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await RegistrationPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
