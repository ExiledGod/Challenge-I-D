using DemoDashboardDevice.Models;
using DemoDashboardDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace DemoDashboardDevice.Repositories
{
    public class employe_repository : Iemploye_repository
    {
        private MySQLConfiguration _connectionString;
        public employe_repository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteEmployes(employes employe)
        {
            var db = dbConnection();
            var sql = @"Select from employe where id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = employe.id });
            return result > 0;
        }

        public async Task<IEnumerable<employes>> GetAllemployes()
        {
            var db = dbConnection();
            var sql = @"Select * from employe";
            return await db.QueryAsync<employes>(sql, new { });
        }

        public async Task<employes> GetEmployesDetails(int id)
        {
            var db = dbConnection();
            var sql = @"Select * from employe where id = @Id";
            return await db.QueryFirstOrDefaultAsync<employes>(sql, new { Id = id });
        }

        public async Task<bool> InsertEmployes(employes employe)
        {
            var db = dbConnection();
            var sql = @"
                        Insert into employe (name,rut,company_name,img_name,img_ref_validator) 
                        values (@name),(@rut),(@company_name),(@img_name),(@img_ref_validator)";
            var result = await db.ExecuteAsync(sql, new { employe.name, employe.rut, employe.company_name, employe.img_name, employe.img_ref_validator });
            return result > 0; //result es el numero de filas afectadas
        }

        public async Task<bool> UpdateEmployes(employes employe)
        {
            var db = dbConnection();
            var sql = @"
                        update employe
                            set name = @name,rut = @rut,company_name = @company_name,img_name = @img_name,img_ref_validator = @img_ref_validator
                        where id = @id)";
            var result = await db.ExecuteAsync(sql, new { employe.name, employe.rut, employe.company_name, employe.img_name, employe.img_ref_validator, employe.id });
            return result > 0;
        }
    }
}
