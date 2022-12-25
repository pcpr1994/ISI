using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ISIParkAPI.Data.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private MySQLConfiguration _connectionString;

        public SectorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Sector>> GetAllSector()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM setor";
            return await db.QueryAsync<Sector>(sql, new { });
        }
        public async Task<Sector> GetSectorDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM setor
                        WHERE id_setor = @ID_Setor";
            return await db.QueryFirstOrDefaultAsync<Sector>(sql, new { ID_Setor = id });
        }
        public async Task<bool> InsertSector(Sector setor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO setor (setor, total_lugares)
                        VALUES (@setor, @total_lugares)";

            var result = await db.ExecuteAsync(sql, new
            {
                setor.Setor,
                setor.Total_Lugares
            });

            return result > 0;
        }

        public async Task<bool> UpdateSector(Sector setor)
        {
            var db = dbConnection();
            var sql = @"UPDATE setor
                        SET setor = @Setor, total_lugares = @Total_Lugares
                        WHERE @ID_Setor = id_setor";

            var result = await db.ExecuteAsync(sql, new
            {
                setor.Setor,
                setor.Total_Lugares,
                setor.ID_Setor
            });

            return result > 0;
        }
        public async Task<bool> DeleteSector(Sector setor)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM setor
                        WHERE id_setor = @ID_Setor";
            var result = await db.ExecuteAsync(sql, new { ID_Setor = setor.ID_Setor });
            return result > 0;
        }
    }
}
