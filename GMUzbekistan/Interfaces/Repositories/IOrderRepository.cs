using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface IOrderRepository :
        ICreateable<Order>, IUpdateable<Order>, IReadable<Order>, IDeleteable<Order>
    {
    }
}
