using DemoDashboardDevice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoDashboardDevice.Repositories
{
    public interface Iemploye_repository
    {
        Task<IEnumerable<employes>> GetAllemployes();
        Task<employes> GetEmployesDetails(int id);
        Task<bool> InsertEmployes(employes employe);
        Task<bool> UpdateEmployes(employes employe);
        Task<bool> DeleteEmployes(employes employe);
        Task<employes> Save(employes employes);
        Task<employes> GetSaveEmploye(int id);

    }
}
