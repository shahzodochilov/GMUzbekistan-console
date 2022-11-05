using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface IClientRepository :
        ICreateable<Client>, IReadable<Client>, IDeleteable<Client>, IUpdateable<Client>
    {
    }
}
