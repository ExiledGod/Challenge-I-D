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
        Task<IEnumerable<employes>> GetInterfacesAsync();
    }
}
