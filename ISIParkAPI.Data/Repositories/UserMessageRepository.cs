/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class UserMessageRepository : IUserMessageRepository
    {
        private MySQLConfiguration _connectionString;

        public UserMessageRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<UserMessage>> GetAllUserMessage()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Mensagem";
            return await db.QueryAsync<UserMessage>(sql, new { });
        }
        public async Task<UserMessage> GetUserMessageID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Mensagemid_mensagem
                        FROM utilizador_Mensagem
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserMessage>(sql, new { Utilizadorid = utilizadorid });
        }
        public async Task<bool> InsertUserMessage(UserMessage userMessage)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Mensagem (utilizadorid, Mensagemid_mensagem)
                        VALUES (@utilizadorid, @Mensagemid_mensagem)";

            var result = await db.ExecuteAsync(sql, new
            {
                userMessage.Mensagemid_mensagem,
                userMessage.Utilizadorid
            });

            return result > 0;
        }

        public async Task<bool> UpdateUserMessage(UserMessage userMessage)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Mensagem
                        SET Mensagemid_mensagem = @Mensagemid_mensagem
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userMessage.Mensagemid_mensagem,
                userMessage.Utilizadorid
            });

            return result > 0;
        }
        public async Task<bool> DeleteUserMessage(UserMessage userMessage)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Mensagem
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { Utilizadorid = userMessage.Utilizadorid });
            return result > 0;
        }


    }
}
