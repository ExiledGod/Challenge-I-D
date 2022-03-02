using DemoDashboardDevice.Models;
using DemoDashboardDevice.Data;
using DemoDashboardDevice.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace DemoDashboardDevice.Repositories
{
    public class history_repository : Ihistory_repository
    {
        private MySQLConfiguration _connectionString;
        public history_repository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteHistory(register register)
        {
            var db = dbConnection();
            var sql = @"Select from history where id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = register.id });
            return result > 0;
        }
        public async Task<register> GetHistoryDetails(int id)
        {
            var db = dbConnection();
            var sql = @"Select * from history where id = @Id";
            return await db.QueryFirstOrDefaultAsync<register>(sql, new { Id = id });
        }

        public async Task<bool> InsertHistory(register register)
        {
            var db = dbConnection();
            var sql = @"
                        Insert into history (employe_id, entry) 
                        values (@employe_id),(@entry)";
            var result = await db.ExecuteAsync(sql, new { register.employe_id,register.entry }); //bajo el supuesto que marca entrada y queda logeado (status working) la sig marcacion seria un update hasta marcar salida
            return result > 0; //result es el numero de filas afectadas
        }

        public async Task<bool> UpdateHistory(register register)
        {
            var db = dbConnection();
            var sql = "";
            //si es null es el sig registro en llenar
            if (register.colation == null) {
                sql = @"
                        update history
                            set colation = @colation
                        where id = @id)";
                var result = await db.ExecuteAsync(sql, new { register.colation, register.id });
                return result > 0;
            }
            //si es null y el anterior existe es el sig registro en llenar
            if (register.end_colation == null && register.colation != null)
            {
                sql = @"
                        update history
                            set end_colation = @end_colation
                        where id = @id)";
                var result = await db.ExecuteAsync(sql, new { register.end_colation, register.id });
                return result > 0;
            }
            if (register.endturn == null && register.end_colation != null)
            {
                sql = @"
                        update history
                            set endturn = @endturn
                        where id = @id)";
                var result = await db.ExecuteAsync(sql, new { register.endturn, register.id });
                return result > 0;
            }
            return false;
        }

        public async Task<IEnumerable<register>> GetAllHistory()
        {
            var db = dbConnection();
            var sql = @"Select * from history";
            return await db.QueryAsync<register>(sql, new { });
        }
    }
}
