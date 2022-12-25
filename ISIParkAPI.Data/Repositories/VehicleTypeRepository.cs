using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private MySQLConfiguration _connectionString;

        public VehicleTypeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<VehicleType>> GetAllVehicleType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                    FROM Tipo_veiculos";
            return await db.QueryAsync<VehicleType>(sql, new { });
        }
        public async Task<VehicleType> GetVehicleTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id_veiculo, descricao
                    FROM Tipo_veiculos
                    WHERE id_veiculo = @ID_Veiculo";
            return await db.QueryFirstOrDefaultAsync<VehicleType>(sql, new { ID_Veiculo = id });
        }
        public async Task<bool> InsertVehicleType(VehicleType vehicleType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Tipo_veiculos (descricao)
                    VALUES (@descricao)";

            var result = await db.ExecuteAsync(sql, new
            {
                vehicleType.Descricao
            });

            return result > 0;
        }

        public async Task<bool> UpdateVehicleType(VehicleType vehicleType)
        {
            var db = dbConnection();
            var sql = @"UPDATE Tipo_veiculos
                    SET descricao = @Descricao
                    WHERE ID_Veiculo = @id_veiculo";

            var result = await db.ExecuteAsync(sql, new
            {
                vehicleType.Descricao,
                vehicleType.ID_Veiculo
            });

            return result > 0;
        }
        public async Task<bool> DeleteVehicleType(VehicleType vehicleType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                    FROM Tipo_veiculos
                    WHERE id_veiculo = @ID_Veiculo";
            var result = await db.ExecuteAsync(sql, new { ID_Veiculo = vehicleType.ID_Veiculo });
            return result > 0;
        }
        
    }
}
