using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private MySQLConfiguration _connectionString;
        public UserTypeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<UserType>> GetAllUserType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM tipo_utilizador";
            return await db.QueryAsync<UserType>(sql, new { });
        }
        public async Task<UserType> GetUserTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nome_tipo
                        FROM tipo_utilizador
                        WHERE id = @ID";
            return await db.QueryFirstOrDefaultAsync<UserType>(sql, new { ID = id });
        }
        public async Task<bool> InsertUserType(UserType userType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tipo_utilizador (nome_tipo)
                        VALUES (@nome_tipo)";

            var result = await db.ExecuteAsync(sql, new
            {
                userType.Nome_tipo
            });

            return result > 0;
        }

        public async Task<bool> UpdateUserType(UserType userType)
        {
            var db = dbConnection();
            var sql = @"UPDATE tipo_utilizador
                        SET nome_tipo = @Nome_tipo
                        WHERE ID = id";

            var result = await db.ExecuteAsync(sql, new
            {
                userType.Nome_tipo,
                userType.ID
            });

            return result > 0;
        }
        public async Task<bool> DeleteUserType(UserType userType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM tipo_utilizador
                        WHERE id = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = userType.ID });
            return result > 0;
        }
    }
}

