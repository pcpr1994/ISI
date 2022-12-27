using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class PlaceTypeRepository : IPlaceTypeRepository
    {
        private MySQLConfiguration _connectionString;

        public PlaceTypeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<PlaceType>> GetAllPlaceType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM tipo_lugar";
            return await db.QueryAsync<PlaceType>(sql, new { });
        }
        public async Task<PlaceType> GetPlaceTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT n_tipo, descricao
                        FROM tipo_lugar
                        WHERE n_tipo = @N_Tipo";
            return await db.QueryFirstOrDefaultAsync<PlaceType>(sql, new { N_Tipo = id });
        }
        public async Task<bool> InsertPlaceType(PlaceType placeType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tipo_lugar (descricao)
                        VALUES (@descricao)";

            var result = await db.ExecuteAsync(sql, new
            {
                placeType.Descricao
            });

            return result > 0;
        }

        public async Task<bool> UpdatePlaceType(PlaceType placeType)
        {
            var db = dbConnection();
            var sql = @"UPDATE tipo_lugar
                        SET descricao = @Descricao
                        WHERE N_Tipo = @n_tipo";

            var result = await db.ExecuteAsync(sql, new
            {
                placeType.Descricao,
                placeType.N_Tipo
            });

            return result > 0;
        }
        public async Task<bool> DeletePlaceType(PlaceType placeType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM tipo_lugar
                        WHERE n_tipo = @N_Tipo";
            var result = await db.ExecuteAsync(sql, new { N_Tipo = placeType.N_Tipo });
            return result > 0;
        }
    }
}
