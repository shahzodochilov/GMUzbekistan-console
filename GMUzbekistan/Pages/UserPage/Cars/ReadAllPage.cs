using ConsoleTables;
using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Repositories;
using System.Threading.Tasks;
using System;

namespace GMUzbekistan.Pages.UserPage.Cars
{
    public class ReadAllPage
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
            var cars = await carRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Narxi", "Rangi",
                "O'rindiqlar soni", "Transmission", "Safety");

            foreach (var car in cars)
            {
                consoleTable.AddRow(car.Id, car.Name, car.Price, car.Color.ToString(), car.NumberOfSeats,
                    car.Transmission.ToString(), car.Safety.ToString());
            }
            consoleTable.Write();
        }
    }
}
