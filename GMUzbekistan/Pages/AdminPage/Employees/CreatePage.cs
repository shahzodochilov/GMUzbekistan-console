using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Employees
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Employee employee = new Employee();
            Console.WriteLine("******   Xodim qo'shish    ******");
            Console.WriteLine("Id :  ");
            employee.Id = int.Parse(Console.ReadLine());
            Console.Write("Familiya-ism :  ");
            employee.Name = Console.ReadLine();
            Console.WriteLine("-->>   Jinsini tanlang   <<--");
            Console.WriteLine("1. Erkak     2. Ayol");
            int selected = int.Parse(Console.ReadLine());
            employee.Gender = (selected == 1) ? Enums.Gender.Male : Enums.Gender.Famale;
            Console.Write("Yoshi :  ");
            employee.Age = byte.Parse(Console.ReadLine());
            Console.Write("Oyligi :  ");
            employee.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Xodim mansabini tanlang! ");
            // Director = 1, Manager, Accountant, TechnicalMechanic, Guard,
            Console.WriteLine("1.Direktor  2.Manager  3.Buxgalter  4.Texnik mexanik  5.Qorovul ");
            int t = int.Parse(Console.ReadLine());
            employee.Position = (Enums.EmployeePosition)t;
            Console.Write("Telefon nomeri :  ");
            employee.PhoneNumber = Console.ReadLine();
            Console.Write("Manzili :  ");
            employee.Address = Console.ReadLine();
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            bool created = await employeeRepository.CreateAsync(employee);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat qo'shildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await EmployeePage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
