using DemoDashboardDevice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Repositories
{
    public interface Iperson_repository
    {
        Task<IEnumerable<Person>> GetAllPerson();
        Task<Person> GetPersonDetails(int id);
        Task<bool> InsertPerson(Person person);
        Task<bool> UpdatePerson(Person person);
        Task<bool> DeletePerson(Person person);
        Task<Person> FilterPersonByIdentifier(Person person);
        Task<Person> FilterPersonByCompany(Person person);
    }
}
