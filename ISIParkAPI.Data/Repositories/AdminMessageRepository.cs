using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class AdminMessageRepository : IAdminMessageRepository
    {
        private MySQLConfiguration _connectionString;
        public AdminMessageRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<AdminMessage>> GetAllAdminMessage()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Mensagem_admin";
            return await db.QueryAsync<AdminMessage>(sql, new { });
        }
        public async Task<AdminMessage> GetAdminMessageDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id_mensagem, descricao, data
                        FROM Mensagem_admin
                        WHERE id_mensagem = @Id_Mensagem";
            return await db.QueryFirstOrDefaultAsync<AdminMessage>(sql, new { Id_Mensagem = id });
        }
        public async Task<bool> InsertAdminMessage(AdminMessage adminMensagem)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Mensagem_admin (descricao, data)
                        VALUES (@Descricao, @Data)";

            var result = await db.ExecuteAsync(sql, new
            {
                adminMensagem.Descricao,
                adminMensagem.Data
            });

            return result > 0;
        }

        public async Task<bool> UpdateAdminMessage(AdminMessage adminMessage)
        {
            var db = dbConnection();
            var sql = @"UPDATE Mensagem_admin
                        SET descricao = @Descricao, data = @Data
                        WHERE @id_mensagem = Id_Mensagem";

            var result = await db.ExecuteAsync(sql, new
            {
                adminMessage.Descricao,
                adminMessage.Data,
                adminMessage.Id_Mensagem
            });

            return result > 0;
        }
        public async Task<bool> DeleteAdminMessage(AdminMessage adminMessage)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Mensagem_admin
                        WHERE id_mensagem = @Id_Mensagem";
            var result = await db.ExecuteAsync(sql, new { ID = adminMessage.Id_Mensagem });
            return result > 0;
        }
    }
}
