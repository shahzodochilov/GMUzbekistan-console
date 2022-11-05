using GMUzbekistan.Helpers;
using GMUzbekistan.Security;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage
{
    public class AdminCheckerPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            StatusHelper.InfoMessage("Hurmatli Admin Tizimga kirish uchun Login va Parolingizni kiriting {admin, admin}");
        key:
            Console.Write("Login : ");
            string log = Console.ReadLine();
            Console.Write("Parol : ");
            string pass = Console.ReadLine();
            string passHash = Hasher.HashString(pass, log);
            
            if (passHash == "D82494F05D6917BA02F7AAA29689CCB444BB73F20380876CB05D1F37537B7892")
            {
                await AdminMainPage.RunAsync();
            }
            else
            {
                StatusHelper.InfoMessage("Login yoki parol xato!!!!");
                Console.WriteLine("0. Ortga\n1. Qayta urinish!");
                string t = Console.ReadLine();
                if (t == "0") await MainPage.RunAsync();
                else goto key;
            }
        }
    }
}
