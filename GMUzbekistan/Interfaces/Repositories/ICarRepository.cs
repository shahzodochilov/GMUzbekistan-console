using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface ICarRepository :
        ICreateable<Car>, IUpdateable<Car>, IDeleteable<Car>, IReadable<Car>
    {
    }
}
