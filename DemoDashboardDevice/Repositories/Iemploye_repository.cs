using DemoDashboardDevice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface employe_repository
    {
        Task<IEnumerable<employes>> GetAllemployes();
        Task<employes> GetEmployesDetails();
        Task<bool> InsertEmployes();
        Task<bool> UpdateEmployes();
        Task<bool> DeleteEmployes();

    }
}
