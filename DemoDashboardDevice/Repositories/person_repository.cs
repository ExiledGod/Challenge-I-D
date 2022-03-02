using Dapper;
using DemoDashboardDevice.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoDashboardDevice.Repositories
{
    public class person_repository : Iperson_repository
    {

        private MySQLConfiguration _connectionString;
        public person_repository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeletePerson(Person person)
        {
            var db = dbConnection();
            var sql = @"delete from person where id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = person.id });
            return result > 0;
        }

        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            var db = dbConnection();
            var sql = @"Select * from person";
            return await db.QueryAsync<Person>(sql, new { });
        }

        public async Task<Person> GetPersonDetails(int id)
        {
            var db = dbConnection();
            var sql = @"Select * from persona where id = @Id";
            return await db.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }

        public async Task<bool> InsertPerson(Person person)
        {
            var db = dbConnection();
            var sql = @"
                        Insert into person (name, identity_number, proximity_card, allowed_methods, company_id, company_name, devices, devices_name) 
                        values (@name),(@identity_number),(@proximity_card),(@allowed_methods),(@company_id),(@company_name),(@devices),(@devices_name)";
            var result = await db.ExecuteAsync(sql, new { person.name, person.identity_number, person.proximity_card, person.allowed_methods, person.company_id, person.company_name, person.devices, person.devices_name });
            return result > 0;
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            var db = dbConnection();
            var sql = @"
                        update employe
                            set @name = person.name, @identity_number = person.identity_number, @proximity_card = person.proximity_card, @allowed_methods = person.allowed_methods, @company_id = person.company_id, @company_name = person.company_name, @devices = person.devices, @devices_name = person.devices_name
                        where id = @id)";
            var result = await db.ExecuteAsync(sql, new { person.name, person.identity_number, person.proximity_card, person.allowed_methods, person.company_id, person.company_name, person.devices, person.devices_name, person.id });
            return result > 0;
        }

        public async Task<Person> FilterPersonByIdentifier(Person person)
        {
            var db = dbConnection();
            var sql = @"Select * from persona where identity_number = @identity_number";
            return (Person)await db.QueryAsync(sql, new { person.identity_number });
        }

        public async Task<Person> FilterPersonByCompany(Person person)
        {
            var db = dbConnection();
            var sql = @"Select * from persona where company_id = @company_id";
            return (Person)await db.QueryAsync(sql, new { person.company_id });
        }
    }
}
