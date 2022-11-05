using GMUzbekistan.Constants;
using GMUzbekistan.Interfaces.Repositories;
using GMUzbekistan.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GMUzbekistan.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly string dbPath = DbConstants.CarDbPath;

        public async Task<bool> CreateAsync(Car obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<Car>>(json);
                list.Add(obj);
                json = JsonConvert.SerializeObject(list);
                await File.WriteAllTextAsync(dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<Car>>(json);
                int index = list.TakeWhile(x => x.Id != Id).Count();
                list.RemoveAt(index);
                json = JsonConvert.SerializeObject(list);
                await File.WriteAllTextAsync(dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Car>> GetAllAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<Car>>(json);
                return list;
            }
            catch
            {
                return new List<Car>();
            }
        }

        public async Task<Car> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<Car>>(json);
                int index = list.TakeWhile(x => x.Id != id).Count();
                return list.ElementAt(index);
            }
            catch
            {
                return new Car();
            }
        }

        public async Task<bool> UpdateAsync(int Id, Car obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<Car>>(json);
                int index = list.TakeWhile(x => x.Id != Id).Count();
                list[index] = obj;
                json = JsonConvert.SerializeObject(list);
                await File.WriteAllTextAsync(dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
