using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private MySQLConfiguration _connectionString;

        public ContactTypeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<ContactType>> GetAllContactType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Tipo_contacto";
            return await db.QueryAsync<ContactType>(sql, new { });
        }
        public async Task<ContactType> GetContactTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, descricao
                        FROM Tipo_contacto
                        WHERE id = @ID";
            return await db.QueryFirstOrDefaultAsync<ContactType>(sql, new { ID = id });
        }
        public async Task<bool> InsertContactType(ContactType contactoType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Tipo_contacto (descricao)
                        VALUES (@descricao)";

            var result = await db.ExecuteAsync(sql, new
            {
                contactoType.Descricao
            });

            return result > 0;
        }

        public async Task<bool> UpdateContactType(ContactType contactType)
        {
            var db = dbConnection();
            var sql = @"UPDATE Tipo_contacto
                        SET descricao = @Descricao
                        WHERE ID = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                contactType.Descricao,
                contactType.ID
            });

            return result > 0;
        }
        public async Task<bool> DeleteContactType(ContactType contactType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Tipo_contacto
                        WHERE id = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = contactType.ID });
            return result > 0;
        }
    }
}
