using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System.Threading.Tasks;
using System;

namespace GMUzbekistan.Pages.AdminPage.VacantPositions
{
    public class ReadAllPage
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
            var vacantPositions = await vacantPositionRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Lavozim", "Maoshi", "O'rinlar soni");

            foreach (var item in vacantPositions)
            {
                string position;
                //Director, Manager, Accountant, TechnicalMechanic, Guard
                if (item.Position == Enums.EmployeePosition.Guard) position = "Qorovul";
                else if (item.Position == Enums.EmployeePosition.Manager) position = "Menejer";
                else if (item.Position == Enums.EmployeePosition.Manager) position = "Manager";
                else if (item.Position == Enums.EmployeePosition.Accountant) position = "Buxgalter";
                else if (item.Position == Enums.EmployeePosition.TechnicalMechanic) position = "Texnik Mexanik";
                else position = "Direktor";

                consoleTable.AddRow(item.Id, position, item.Salary, item.Number);
            }
            consoleTable.Write();
        }
    }
}
