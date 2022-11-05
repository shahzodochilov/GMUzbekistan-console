using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System.Threading.Tasks;
using System;

namespace GMUzbekistan.Pages.AdminPage.Employees
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await EmployeePage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
        public static async Task ShowDataAsync()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            var Employees = await employeeRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Yoshi", "Maoshi", "Telefon nomeri", "Mansabi", "Jinsi", "Manzili");

            foreach (var item in Employees)
            {
                string gender;
                if (item.Gender == Enums.Gender.Male) gender = "Erkak";
                else gender = "Ayol";
                string position;
                //Director, Manager, Accountant, TechnicalMechanic, Guard
                if (item.Position == Enums.EmployeePosition.Guard) position = "Qorovul";
                else if (item.Position == Enums.EmployeePosition.Manager) position = "Menejer";
                else if (item.Position == Enums.EmployeePosition.Manager) position = "Manager";
                else if (item.Position == Enums.EmployeePosition.Accountant) position = "Buxgalter";
                else if (item.Position == Enums.EmployeePosition.TechnicalMechanic) position = "Texnik Mexanik";
                else position = "Direktor";

                consoleTable.AddRow(item.Id, item.Name, item.Age, item.Salary, item.PhoneNumber, position, gender, item.Address);
            }
            consoleTable.Write();
        }
    }
}
