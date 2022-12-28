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
    public class UserVechicleTypeRepository : IUserVechicleTypeRepository
    {
        private MySQLConfiguration _connectionString;

        public UserVechicleTypeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<UserVechicleType>> GetAllUserVechicleTypey()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Tipo_veiculos";
            return await db.QueryAsync<UserVechicleType>(sql, new { });
        }
        public async Task<UserVechicleType> GetUserVechicleTypeID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Tipo_veiculosid_veiculo, matricula
                        FROM utilizador_Tipo_veiculos
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserVechicleType>(sql, new { Utilizadorid = utilizadorid });
        }
        public async Task<bool> InsertUserVechicleType(UserVechicleType userVechicleType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Tipo_veiculos (utilizadorid, Tipo_veiculosid_veiculo, matricula)
                        VALUES (@utilizadorid, @Tipo_veiculosid_veiculo, @matricula)";

            var result = await db.ExecuteAsync(sql, new
            {
                userVechicleType.Utilizadorid,
                userVechicleType.Tipo_veiculosid_veiculo,
                userVechicleType.Matricula
            });

            return result > 0;
        }

        public async Task<bool> UpdateUserVechicleType(UserVechicleType userVechicleType)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Tipo_veiculos
                        SET Tipo_veiculosid_veiculo = @Tipo_veiculosid_veiculo, matricula = @matricula
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userVechicleType.Tipo_veiculosid_veiculo,
                userVechicleType.Matricula,
                userVechicleType.Utilizadorid
            });

            return result > 0;
        }
        public async Task<bool> DeleteUserVechicleType(UserVechicleType userVechicleType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Tipo_veiculos
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { Utilizadorid = userVechicleType.Utilizadorid });
            return result > 0;
        }

    }
}
