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
    public class UserRepository: IUserRepository
    {
        private MySQLConfiguration _connectionString;
        public UserRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            var db = dbConnection();
            var sql = @"SELECT id, nome, nif, DataNasc, genero, tipo_utilizadorid, Moradaid_morada, email, password
                        FROM utilizador";
            return await db.QueryAsync<UserDTO>(sql, new { });
        }
       
        public async Task<UserDTO> GetUserById(int numero)
        {
            var db = dbConnection();
            var sql = @"SELECT nome, nif, DataNasc, genero, tipo_utilizadorid, Moradaid_morada, email, password
                        FROM utilizador
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Id = numero });
        }
        public async Task<bool> InsertUser(UserDTO user)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador (nome, nif, DataNasc, genero, tipo_utilizadorid, 
                                    Moradaid_morada, email, password)
                         VALUES (@nome, @nif, @DataNasc, @genero, @tipo_utilizadorid, @Moradaid_morada, @email, @password)";  
                       

            var result = await db.ExecuteAsync(sql, new
            {
                user.Nome,
                user.Nif,
                user.DataNasc,
                user.Genero,
                user.Tipo_utilizadorid,
                user.Moradaid_morada,
                user.Email,
                user.Password

            });

            return result > 0;
        }

        public async Task<bool> UpdateUser(UserDTO user)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador
                        SET nome = @Nome, nif = @Nif, DataNasc = @DataNasc, genero = @Genero, tipo_utilizadorid = @Tipo_utilizadorid, 
                                    Moradaid_morada = @Moradaid_morada, email = @Email, password = @Password
                        WHERE @id = Id";

            var result = await db.ExecuteAsync(sql, new
            {
                user.Id,
                user.Nome,
                user.Nif,
                user.DataNasc,
                user.Genero,
                user.Tipo_utilizadorid,
                user.Moradaid_morada,
                user.Email,
                user.Password

                
            });

            return result > 0;
        }
        public async Task<bool> DeleteUser(UserDTO user)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador
                        WHERE @id = Id";
            var result = await db.ExecuteAsync(sql, new { Id = user.Id });
            return result > 0;
        }

    }
}
