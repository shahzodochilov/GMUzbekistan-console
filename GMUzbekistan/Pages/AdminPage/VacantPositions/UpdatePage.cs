﻿using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using System;
using System.Threading.Tasks;

namespace GMUzbekistan.Pages.AdminPage.VacantPositions
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            VacantPosition vacantPosition = new VacantPosition();
            Console.WriteLine("******   Vakantsiyani tahrirlash    ******");
            Console.WriteLine("Id sini kiriting:  ");
            int id = int.Parse(Console.ReadLine());
            vacantPosition.Id = id;
            Console.WriteLine("Lavozimni tanlang! ");
            Console.WriteLine("1.Direktor  2.Manager  3.Buxgalter  4.Texnik mexanik  5.Qorovul ");
            int t = int.Parse(Console.ReadLine());
            vacantPosition.Position = (Enums.EmployeePosition)t;
            Console.Write("Oyligi :  ");
            vacantPosition.Salary = int.Parse(Console.ReadLine());
            Console.Write("O'rinlar soni :  ");
            vacantPosition.Number = int.Parse(Console.ReadLine());

            IVacantPositionRepository vacantPositionRepository = new VacantPositionRepository();
            bool created = await vacantPositionRepository.UpdateAsync(id, vacantPosition);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat yangilandi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");

            Console.WriteLine("\n1. Ortga.\n2. Bosh sahifa.\n3. Chiqish");
            string temp = Console.ReadLine();
            if (temp == "1") await VacantPositionPage.RunAsync();
            else if (temp == "2") await MainPage.RunAsync();
            else return;
        }
    }
}
