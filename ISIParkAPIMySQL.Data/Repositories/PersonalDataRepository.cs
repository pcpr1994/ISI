using Dapper;
using ISIParkAPIMySQL.Model;
using MySql.Data.MySqlClient;

namespace ISIParkAPIMySQL.Data.Repositories
{
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private MySQLConfiguration _connectionString;
        public PersonalDataRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<PersonalData>> GetAllPersonalData()
        {
            var db = dbConnection();
            var sql = @"SELECT numero, nome, cp4, cp3, rua, contacto, nif, email, 
                        password, dataNasc, genero, tipo_utilizador, pagamento
                        FROM dados_pessoais";
            return await db.QueryAsync<PersonalData>(sql, new { });
        }
        public async Task<PersonalData> GetPersonalDataDetails(int numero)
        {
            var db = dbConnection();
            var sql = @"SELECT numero, nome, cp4, cp3, rua, contacto, nif, email, 
                        password, dataNasc, genero, tipo_utilizador, pagamento
                        FROM dados_pessoais
                        WHERE numero = @Numero";
            return await db.QueryFirstOrDefaultAsync<PersonalData>(sql, new { Numero = numero });
        }
        public async Task<bool> InsertPersonalData(PersonalData personalData)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO dados_pessoais (nome, cp4, cp3, rua, contacto, nif, email, 
                        password, dataNasc, genero, tipo_utilizador, pagamento)
                        VALUES (@nome, @cp4, @cp3, @rua, @contacto, @nif, @email, 
                        @password, @dataNasc, @genero, @tipo_utilizador, @pagamento)";

            var result =  await db.ExecuteAsync(sql, new {personalData.Nome, personalData.CP4, personalData.CP3,
            personalData.Rua, personalData.Contacto, personalData.NIF, personalData.Email, personalData.Password,
            personalData.DataNasc, personalData.Genero, personalData.TipoUtilizador, personalData.Pagamento});

            return result > 0;
        }

        public async Task<bool> UpdatePersonalData(PersonalData personalData)
        {
            var db = dbConnection();
            var sql = @"UPDATE dados_pessoais
                        SET nome = @Nome, cp4 = @CP4, cp3 = @CP3, rua = @Rua, contacto = @Contacto, nif = @NIF, 
                        email = @Email, password = @Password, dataNasc = @DataNasc, genero = @Genero,
                        tipo_utilizador = @TipoUtilizador, pagamento = @Pagamento
                        WHERE Numero = numero";

            var result = await db.ExecuteAsync(sql, new { personalData.Nome, personalData.CP4, personalData.CP3,
                personalData.Rua, personalData.Contacto, personalData.NIF, personalData.Email, personalData.Password,
                personalData.DataNasc, personalData.Genero, personalData.TipoUtilizador, personalData.Pagamento,
                personalData.Numero});

            return result > 0;
        }
        public async Task<bool> DeletePersonalData(PersonalData personalData)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM dados_pessoais
                        WHERE numero = @Numero";
            var result = await db.ExecuteAsync(sql, new { Numero = personalData.Numero });
            return result > 0;
        }
    }
}
