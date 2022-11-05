using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface IContactUsRepository :
        ICreateable<ContactUs>, IReadable<ContactUs>, IDeleteable<ContactUs>, IUpdateable<ContactUs>
    {
    }
}
