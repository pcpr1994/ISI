namespace ISIParkAPI.Data
{
    /// <summary>
    /// Classe para configuração de ligação à base de dados MySQL
    /// </summary>
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
