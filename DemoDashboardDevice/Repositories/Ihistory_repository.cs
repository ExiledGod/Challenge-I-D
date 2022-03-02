using DemoDashboardDevice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Repositories
{
    public interface Ihistory_repository
    {
        Task<IEnumerable<register>> GetAllHistory();
        Task<register> GetHistoryDetails(int id);
        Task<bool> InsertHistory(register register);
        Task<bool> UpdateHistory(register register);
        Task<bool> DeleteHistory(register register);
    }
}
