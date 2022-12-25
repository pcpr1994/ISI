using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private MySQLConfiguration _connectionString;
        public HistoryRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<History>> GetAllHistory()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Historico";
            return await db.QueryAsync<History>(sql, new { });
        }
        public async Task<History> GetHistoryDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, dia, hora_entrada, hora_saida, lugarnumero_lugar
                        FROM Historico
                        WHERE id = @ID";
            return await db.QueryFirstOrDefaultAsync<History>(sql, new { ID = id });
        }
        public async Task<bool> InsertHistory(History history)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Historico (dia, hora_entrada, hora_saida, lugarnumero_lugar)
                        VALUES (@dia, @hora_entrada, @hora_saida, @lugarnumero_lugar)";

            var result = await db.ExecuteAsync(sql, new
            {
                history.Dia,
                history.Hora_entrada,
                history.Hora_saida,
                history.Lugarnumero_lugar
            });

            return result > 0;
        }

        public async Task<bool> UpdateHistory(History history)
        {
            var db = dbConnection();
            var sql = @"UPDATE Historico
                        SET dia = @Dia, hora_entrada = @Hora_entrada, hora_saida = @Hora_saida, 
                            lugarnumero_lugar = @Lugarnumero_lugar
                        WHERE @id = ID";

            var result = await db.ExecuteAsync(sql, new
            {
                history.Dia,
                history.Hora_entrada,
                history.Hora_saida,         
                history.ID
            });

            return result > 0;
        }
        public async Task<bool> DeleteHistory(History history)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Historico
                        WHERE id = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = history.ID });
            return result > 0;
        }
    }
}
