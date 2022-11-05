using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.Cars
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Car car = new Car();
            Console.WriteLine("******   Yangi Avtomobil qo'shish    ******");
            Console.Write("Id :  ");
            car.Id = int.Parse(Console.ReadLine());
            Console.Write("Nomi :  ");
            car.Name = Console.ReadLine();
            Console.Write("Narxi :  ");
            car.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Rangini tanlang! \n1. Red  2. Pink 3. Orange " +
                "4. Yellow 5. Purple 6. Green 7. Blue 8. Brown 9. White  10. Black");
            int selected = int.Parse(Console.ReadLine());
            car.Color = (Enums.CarColor)selected;
            Console.WriteLine("O'rindiqlar soni :  ");
            car.NumberOfSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Avtomat   2. Mexanik");
            selected = int.Parse(Console.ReadLine());
            car.Transmission = (Enums.CarTransmission)selected;
            Console.WriteLine("1. ABS 2. ESC 3. NonABS");
            selected = int.Parse(Console.ReadLine());
            car.Safety = (Enums.CarSafety)selected;

            ICarRepository carRepository = new CarRepository();
            bool created = await carRepository.CreateAsync(car);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat qo'shildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await CarPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
