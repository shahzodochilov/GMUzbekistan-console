using GMUzbekistan.Interfaces.Common;
using GMUzbekistan.Models;

namespace GMUzbekistan.Interfaces.Repositories
{
    public interface ICompanyInformationRepository :
        ICreateable<CompanyInformation>, IReadable<CompanyInformation>, IDeleteable<CompanyInformation>, IUpdateable<CompanyInformation>
    {
    }
}
