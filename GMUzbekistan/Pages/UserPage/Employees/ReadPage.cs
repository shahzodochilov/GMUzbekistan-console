using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.Employees
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            Console.WriteLine("Xodim Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());
            var employee = await employeeRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Yoshi", "Maoshi", "Telefon nomeri", "Mansabi", "Jinsi", "Manzili");
            string gender;
            if (employee.Gender == Enums.Gender.Male) gender = "Erkak";
            else gender = "Ayol";
            string position;
            if (employee.Position == Enums.EmployeePosition.Guard) position = "Qorovul";
            else if (employee.Position == Enums.EmployeePosition.Manager) position = "Menejer";
            else if (employee.Position == Enums.EmployeePosition.Manager) position = "Manager";
            else if (employee.Position == Enums.EmployeePosition.Accountant) position = "Buxgalter";
            else if (employee.Position == Enums.EmployeePosition.TechnicalMechanic) position = "Texnik Mexanik";
            else position = "Direktor";

            consoleTable.AddRow(employee.Id, employee.Name, employee.Age, employee.Salary, employee.PhoneNumber, position, gender, employee.Address);

            consoleTable.Write();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await EmployeePage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
