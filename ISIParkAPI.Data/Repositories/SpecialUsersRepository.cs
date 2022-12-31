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
    public class SpecialUsersRepository : ISpecialUsersRepository
    {

        private MySQLConfiguration _connectionString;

        public SpecialUsersRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<SpecialUser>> GetAllSpecialUser()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM perfil_especial";
            return await db.QueryAsync<SpecialUser>(sql, new { });
        }


        public async Task<SpecialUser> GetSpecialUserByID(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT nome, matricula, contacto, Tipo_veiculosid_veiculo
                        FROM perfil_especial
                        WHERE id = @ID";

            return await db.QueryFirstOrDefaultAsync<SpecialUser>(sql, new { ID = id });
        }

        public async Task<bool> InsertSpecialUser(SpecialUser specialUser)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO perfil_especial (nome, matricula, contacto, Tipo_veiculosid_veiculo)
                        VALUES (@nome, @matricula, @contacto, @Tipo_veiculosid_veiculo)";

            var result = await db.ExecuteAsync(sql, new
            {
                specialUser.Nome,
                specialUser.Matricula,
                specialUser.Contacto,
                specialUser.Tipo_veiculosid_veiculo,
                specialUser.Id

            });

            return result > 0;
        }

        public async Task<bool> UpdateSpecialUser(SpecialUser specialUser)
        {
            var db = dbConnection();
            var sql = @"UPDATE perfil_especial
                        SET nome = @nome, matricula = @matricula, contacto = @contacto, 
                                Tipo_veiculosid_veiculo = @Tipo_veiculosid_veiculo
                        WHERE @id = Id";

            var result = await db.ExecuteAsync(sql, new
            {
                specialUser.Nome,
                specialUser.Matricula,
                specialUser.Contacto,
                specialUser.Tipo_veiculosid_veiculo,
                specialUser.Id
            });

            return result > 0;
        }

        public async Task<bool> DeleteSpecialUser(SpecialUser specialUser)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM perfil_especial
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = specialUser.Id });
            return result > 0;
        }




    }
}
