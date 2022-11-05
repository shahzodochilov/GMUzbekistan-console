using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.VacantPositions
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IVacantPositionRepository vacantPositionRepository = new VacantPositionRepository();
            Console.Write("Vakantsiya Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await vacantPositionRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Vakantsiya muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Xodim ma'lumotlarini o'chirib bo'lmadi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await VacantPositionPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
