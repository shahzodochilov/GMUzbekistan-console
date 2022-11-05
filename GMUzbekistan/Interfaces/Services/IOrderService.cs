using GMUzbekistan.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMUzbekistan.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IList<OrderViewModel>> GetAllAsync();

        Task<OrderViewModel> GetAsync(int id);

        Task<bool> CreateAsync();

        Task<bool> UpdateAsync(int id);
    }
}
