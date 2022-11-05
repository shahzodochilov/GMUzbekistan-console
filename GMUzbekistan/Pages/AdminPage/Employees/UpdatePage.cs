using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Employees
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Employee employee = new Employee();
            Console.WriteLine("******   Xodim ma'lumotlarini yangilash    ******");
            Console.WriteLine("Xodim Id sini kiriting :  ");
            int employeeid = int.Parse(Console.ReadLine());
            employee.Id = employeeid;
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
            Console.WriteLine("1.Ofitsiant  2.Boshliq  3.Oshpaz  4.Manager  5.Buxgalter  6.Qorovul");
            int t = int.Parse(Console.ReadLine());
            employee.Position = (Enums.EmployeePosition)(t - 1);
            Console.Write("Telefon nomeri :  ");
            employee.PhoneNumber = Console.ReadLine();
            Console.Write("Manzili :  ");
            employee.Address = Console.ReadLine();
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            bool created = await employeeRepository.UpdateAsync(employeeid, employee);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat o'zgartirildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await EmployeePage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
