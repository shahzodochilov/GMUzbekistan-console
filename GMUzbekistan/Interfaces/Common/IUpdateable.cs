using System.Threading.Tasks;

namespace GMUzbekistan.Interfaces.Common
{
    public interface IUpdateable<T>
    {
        Task<bool> UpdateAsync(int Id, T obj);
    }
}
