using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class UserContactTypeRepository : IUserContactTypeRepository
    {
        
        private MySQLConfiguration _connectionString;

        public UserContactTypeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<UserContactType>> GetAllUserContactType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Tipo_contacto";
            return await db.QueryAsync<UserContactType>(sql, new { });
        }
        public async Task<UserContactType> GetUserContactTypeID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Tipo_contacton_contacto, contacto
                        FROM utilizador_Tipo_contacto
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserContactType>(sql, new { utilizadorid = utilizadorid });
        }
        public async Task<bool> InsertUserContactType(UserContactType userContactType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Tipo_contacto (utilizadorid, Tipo_contacton_contacto, contacto)
                        VALUES (@utilizadorid, @Tipo_contacton_contacto, @contacto)";

            var result = await db.ExecuteAsync(sql, new
            {
                userContactType.Tipo_contacton_contacto,
                userContactType.Contacto,
                userContactType.Utilizadorid

            });

            return result > 0;
        }

        public async Task<bool> UpdateUserContactType(UserContactType userContactType)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Tipo_contacto
                        SET Tipo_contacton_contacto = @Tipo_contacton_contacto, contacto = @contacto
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userContactType.Tipo_contacton_contacto,
                userContactType.Contacto,
                userContactType.Utilizadorid

            });

            return result > 0;
        }
        public async Task<bool> DeleteUserContactType(UserContactType userContactType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Tipo_contacto
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { utilizadorid = userContactType.Utilizadorid });
            return result > 0;
        }

       
    }
}
