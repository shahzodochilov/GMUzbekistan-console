using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface IEmployeeRepository :
        ICreateable<Employee>, IUpdateable<Employee>, IReadable<Employee>, IDeleteable<Employee>
    {
    }
}
