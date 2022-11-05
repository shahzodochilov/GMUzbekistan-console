using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.UserPage.Cars
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await CarPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
        public static async Task ShowDataAsync()
        {
            ICarRepository carRepository = new CarRepository();
            Console.Write("Avtomobil Id sini kiriting :  ");
            int id = int.Parse(Console.ReadLine());
            var car = await carRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Narxi", "Rangi",
                "O'rindiqlar soni", "Transmission", "Safety");

            consoleTable.AddRow(car.Id, car.Name, car.Price, car.Color.ToString(), car.NumberOfSeats,
                    car.Transmission.ToString(), car.Safety.ToString());

            consoleTable.Write();
        }
    }
}
