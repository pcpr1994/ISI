/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 */

using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class LicensePlateSensorRepository : ILicensePlateSensorRepository
    {
        private MySQLConfiguration _connectionString;
        public LicensePlateSensorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<LicensePlateSensor>> GetAllPlateSensor()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM sensor_matricula";
            return await db.QueryAsync<LicensePlateSensor>(sql, new { });
        }
        public async Task<LicensePlateSensor> GetPlateSensorDetails(int nif)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM sensor_matricula
                        WHERE nif = @NIF";
            return await db.QueryFirstOrDefaultAsync<LicensePlateSensor>(sql, new { NIF = nif });
        }
        public async Task<bool> InsertVehicleSensor(LicensePlateSensor licensePlateSensor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO sensor_matricula (nif, brand, model, licensePlate, type)
                        VALUES (@nif, @brand, @model, @licensePlate, @type)";

            var result = await db.ExecuteAsync(sql, new
            {
                licensePlateSensor.NIF,
                licensePlateSensor.Brand,
                licensePlateSensor.Model,
                licensePlateSensor.LicensePlate,
                licensePlateSensor.Type
            });

            return result > 0;
        }

        public async Task<bool> UpdateVehicleSensor(LicensePlateSensor licensePlateSensor)
        {
            var db = dbConnection();
            var sql = @"UPDATE sensor_matricula
                        SET nif = @NIF, brand = @Brand, model = @Model, licensePlate = @LicensePlate, type = @Type
                        WHERE @nif = NIF";

            var result = await db.ExecuteAsync(sql, new
            {
                licensePlateSensor.Brand,
                licensePlateSensor.Model,
                licensePlateSensor.LicensePlate,
                licensePlateSensor.Type,
                licensePlateSensor.NIF
            });

            return result > 0;
        }
        public async Task<bool> DeleteVehicleSensor(LicensePlateSensor licensePlateSensor)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM sensor_matricula
                        WHERE nif = @NIF";
            var result = await db.ExecuteAsync(sql, new { NIF = licensePlateSensor.NIF });
            return result > 0;
        }
    }
}
