using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMUzbekistan.Interfaces.Common
{
    public interface IReadable<T>
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(int id);
    }
}
