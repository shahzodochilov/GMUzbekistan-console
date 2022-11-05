        using GMUzbekistan.Helpers;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Interfaces.Services;
using GMUzbekistan.Models;
using GMUzbekistan.Repositories;
using GMUzbekistan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMUzbekistan.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        private readonly IClientRepository clientRepository;

        private readonly ICarRepository carRepository;
        public OrderService()
        {
            this.orderRepository = new OrderRepository();
            this.clientRepository = new ClientRepository();
            this.carRepository = new CarRepository();
        }

        public async Task<bool> CreateAsync()
        {
            try
            {
                Order order = new Order();
                order.Id = (await orderRepository.GetAllAsync()).OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
                Console.WriteLine("--***    Id ingizni kiriting!    ***--\nId  :  ");
                order.ClientId = int.Parse(Console.ReadLine());
                Console.WriteLine("--***    Avtomobil Id sini tanlang!    ***--");
                await Pages.AdminPage.Cars.ReadAllPage.ShowDataAsync();
                Console.Write("Id  :  ");
                int id = int.Parse(Console.ReadLine());
                order.CarId = id;
                order.PurchaseStatus = Enums.OrderPurchaseStatus.New;
                order.Date = DateTime.Now;
                bool created = await orderRepository.CreateAsync(order);
                if (created) StatusHelper.AcceptedMessage($"Hurmatli mijoz Sizning buyurtma Id ingiz : {order.Id}. Id ingizni eslab qoling\n" +
                    $"bu sizga buyurtma holatini ko'rish va qayta tahrir qilish uchun kerak bo'lishi mumkin!");
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IList<OrderViewModel>> GetAllAsync()
        {
            var orders = await orderRepository.GetAllAsync();
            IList<OrderViewModel> orderViewModels = (
                                  from order in orders
                                  join client in await clientRepository.GetAllAsync() on order.ClientId equals client.Id
                                  join car in await carRepository.GetAllAsync() on order.CarId equals car.Id
                                  select new OrderViewModel
                                  {
                                      Id = order.Id,
                                      ClientName = client.Name,
                                      Amount = car.Price,
                                      CarName = car.Name,
                                      PurchaseStatus = order.PurchaseStatus,
                                      Date = order.Date,
                                  }).ToList();
            return orderViewModels;

        }

        public async Task<OrderViewModel> GetAsync(int id)
        {
            var order = await orderRepository.GetAsync(id);
            var client = await clientRepository.GetAsync(order.ClientId);
            var car = await carRepository.GetAsync(order.CarId);

            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Id = order.Id,
                ClientName = client.Name,
                CarName = car.Name,
                Amount = car.Price,
                PurchaseStatus = order.PurchaseStatus,
                Date = order.Date
            };

            return orderViewModel;

        }

        public async Task<bool> UpdateAsync(int id)
        {
            try
            {
                Order order = new Order();
                order.Id = id;
                order.ClientId = (await orderRepository.GetAsync(id)).ClientId;
                Console.WriteLine("--***    Avtomobil Id sini tanlang!    ***--");
                await Pages.AdminPage.Cars.ReadAllPage.ShowDataAsync();
                Console.Write("Id  :  ");
                int carid = int.Parse(Console.ReadLine());
                order.CarId = carid;
                order.PurchaseStatus = Enums.OrderPurchaseStatus.New;
                order.Date = DateTime.Now;
                await orderRepository.UpdateAsync(id, order);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
