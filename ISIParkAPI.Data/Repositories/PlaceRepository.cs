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
    public class PlaceRepository : IPlaceRepository
    {
        private MySQLConfiguration _connectionString;

        public PlaceRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

            public async Task<IEnumerable<Place>> GetAllPlace()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM lugar";
            return await db.QueryAsync<Place>(sql, new { });
        }

        public async Task<Place> GetPlaceById(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT numero_lugar, setorid_setor, tipo_lugarn_tipo, estado, utilizador_Tipo_veiculosmatricula
                        FROM lugar
                        WHERE id = @ID";

            return await db.QueryFirstOrDefaultAsync<Place>(sql, new { ID = id });
        }

        public async Task<bool> InsertPlace(Place place)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO lugar (setorid_setor, tipo_lugarn_tipo, estado, utilizador_Tipo_veiculosmatricula)
                        VALUES (@setorid_setor, @tipo_lugarn_tipo, @estado, @utilizador_Tipo_veiculosmatricula)";

            var result = await db.ExecuteAsync(sql, new
            {
                place.Setorid_setor,
                place.Tipo_lugarn_tipo,
                place.Estado,
                place.Utilizador_Tipo_veiculosmatricula
            });

            return result > 0;
        }

        public async Task<bool> UpdatePlace(Place place)
        {
            var db = dbConnection();
            var sql = @"UPDATE lugar
                        SET setorid_setor = @Setorid_setor, tipo_lugarn_tipo = @Tipo_lugarn_tipo, 
                            estado = @Estado, 
                            utilizador_Tipo_veiculosmatricula = @Utilizador_Tipo_veiculosmatricula
                        WHERE @numero_lugar = Numero_lugar";

            var result = await db.ExecuteAsync(sql, new
            {
                place.Setorid_setor,
                place.Tipo_lugarn_tipo,
                place.Estado,
                place.Utilizador_Tipo_veiculosmatricula,
                place.Numero_lugar

            });

            return result > 0;
        }

        public async Task<bool> DeletePlace(Place place)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM lugar
                        WHERE numero_lugar = @Numero_lugar";
            var result = await db.ExecuteAsync(sql, new { Numero_lugar = place.Numero_lugar });
            return result > 0;
        }

    }
}
