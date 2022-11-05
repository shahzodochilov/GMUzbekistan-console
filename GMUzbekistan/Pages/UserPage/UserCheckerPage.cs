using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using GMUzbekistan.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage
{
    public class UserCheckerPage
    {
        public static async Task RunAsync()
        {   
            Client client = new Client();
            StatusHelper.InfoMessage("Hurmatli Foydalanuvchi Profilga kirish uchun Id va Parolingizni kiriting {pass: 12345}");
            IClientRepository clientRepository = new ClientRepository();
        key:
            Console.Write("Id : ");
            string id = Console.ReadLine();
            client = await clientRepository.GetAsync(int.Parse(id));
            Console.Write("Parol : ");
            string pass = Console.ReadLine();
            string passHash = Hasher.HashString(pass, id);
            if (client.Pass == passHash)
            {
                await UserMainPage.RunAsync();
            }
            else 
            {
                StatusHelper.InfoMessage("Id yoki parol xato!!!!");
                Console.WriteLine("0. Ortga\n1. Qayta urinish!");
                string t = Console.ReadLine();
                if (t == "0") await RegistrationPage.RunAsync();
                else goto key;
            }
        }
    }
}
