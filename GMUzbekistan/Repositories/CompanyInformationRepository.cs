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
    public class CompanyInformationRepository : ICompanyInformationRepository
    {
        private readonly string dbPath = DbConstants.CompanyInformationDbPath;
        public async Task<bool> CreateAsync(CompanyInformation obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<CompanyInformation>>(json);
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
                var list = JsonConvert.DeserializeObject<List<CompanyInformation>>(json);
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

        public async Task<IList<CompanyInformation>> GetAllAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<CompanyInformation>>(json);
                return list;
            }
            catch
            {
                return new List<CompanyInformation>();
            }
        }

        public async Task<CompanyInformation> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<CompanyInformation>>(json);
                int index = list.TakeWhile(x => x.Id != id).Count();
                return list.ElementAt(index);
            }
            catch
            {
                return new CompanyInformation();
            }
        }

        public async Task<bool> UpdateAsync(int Id, CompanyInformation obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(dbPath);
                var list = JsonConvert.DeserializeObject<List<CompanyInformation>>(json);
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
