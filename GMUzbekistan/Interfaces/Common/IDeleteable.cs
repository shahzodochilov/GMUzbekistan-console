using System.Threading.Tasks;

namespace GMUzbekistan.Interfaces.Common
{
    public interface IDeleteable<T>
    {
        Task<bool> DeleteAsync(int Id);
    }
}
