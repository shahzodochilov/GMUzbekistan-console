using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Employees
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            Console.Write("Xodim Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await employeeRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Xodim muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Xodim ma'lumotlarini o'chirib bo'lmadi");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await EmployeePage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
