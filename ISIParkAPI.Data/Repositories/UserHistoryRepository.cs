using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ISIParkAPI.Data.Repositories
{
    public class UserHistoryRepository : IUserHistoryRepository
    {
        private MySQLConfiguration _connectionString;

        public UserHistoryRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<UserHistory>> GetAllUserHistory()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Historico";
            return await db.QueryAsync<UserHistory>(sql, new { });
        }
        public async Task<UserHistory> GetUserHistoryID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Historicoid
                        FROM utilizador_Historico
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserHistory>(sql, new { Utilizadorid = utilizadorid });
        }
        public async Task<bool> InsertUserHistory(UserHistory userHistory)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Historico (utilizadorid, Historicoid)
                        VALUES (@utilizadorid, @Historicoid)";

            var result = await db.ExecuteAsync(sql, new
            {
                userHistory.Utilizadorid,
                userHistory.Historicoid
            });

            return result > 0;
        }

        public async Task<bool> UpdateUserHistory(UserHistory userHistory)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Historico
                        SET Historicoid = @Historicoid
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userHistory.Utilizadorid,
                userHistory.Historicoid
            });

            return result > 0;
        }
        public async Task<bool> DeleteUserHistory(UserHistory userHistory)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Historico
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { Utilizadorid = userHistory.Utilizadorid });
            return result > 0;
        }

    }
}
