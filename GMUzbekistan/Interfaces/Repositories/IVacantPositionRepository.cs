using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface IVacantPositionRepository :
        ICreateable<VacantPosition>, IReadable<VacantPosition>, IUpdateable<VacantPosition>, IDeleteable<VacantPosition>
    {
    }
}
