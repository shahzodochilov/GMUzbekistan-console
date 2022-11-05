using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.VacantPositions
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await VacantPositionPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
        public static async Task ShowDataAsync()
        {
            IVacantPositionRepository vacantPositionRepository = new VacantPositionRepository();
            Console.Write("Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());
            var vacantPosition = await vacantPositionRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Lavozim", "Maoshi", "O'rinlar soni");

            string position;
            //Director, Manager, Accountant, TechnicalMechanic, Guard
            if (vacantPosition.Position == Enums.EmployeePosition.Guard) position = "Qorovul";
            else if (vacantPosition.Position == Enums.EmployeePosition.Manager) position = "Menejer";
            else if (vacantPosition.Position == Enums.EmployeePosition.Manager) position = "Manager";
            else if (vacantPosition.Position == Enums.EmployeePosition.Accountant) position = "Buxgalter";
            else if (vacantPosition.Position == Enums.EmployeePosition.TechnicalMechanic) position = "Texnik Mexanik";
            else position = "Direktor";

            consoleTable.AddRow(vacantPosition.Id, position, vacantPosition.Salary, vacantPosition.Number);

            consoleTable.Write();
        }
    }
}
