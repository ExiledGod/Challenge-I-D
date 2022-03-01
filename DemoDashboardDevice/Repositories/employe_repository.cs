using DemoDashboardDevice.Models;
using NetCoreAPIMySQL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Repositories
{
    public class employe_repository : Iemploye_repository
    {
        public Task<bool> DeleteEmployes()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<employes>> GetAllemployes()
        {
            throw new NotImplementedException();
        }

        public Task<employes> GetEmployesDetails()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertEmployes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployes()
        {
            throw new NotImplementedException();
        }
    }
}
