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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly string dbPath = DbConstants.ContactUsDbPath;
        public async Task<bool> CreateAsync(ContactUs obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<ContactUs>>(json);
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
                var list = JsonConvert.DeserializeObject<List<ContactUs>>(json);
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

        public async Task<IList<ContactUs>> GetAllAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<ContactUs>>(json);
                return list;
            }
            catch
            {
                return new List<ContactUs>();
            }
        }

        public async Task<ContactUs> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<ContactUs>>(json);
                int index = list.TakeWhile(x => x.Id != id).Count();
                return list.ElementAt(index);
            }
            catch
            {
                return new ContactUs();
            }
        }

        public async Task<bool> UpdateAsync(int Id, ContactUs obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<ContactUs>>(json);
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
