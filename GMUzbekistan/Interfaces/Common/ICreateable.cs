using System.Threading.Tasks;

namespace GMUzbekistan.Interfaces.Common
{
    public interface ICreateable<T>
    {
        Task<bool> CreateAsync(T obj);
    }
}
