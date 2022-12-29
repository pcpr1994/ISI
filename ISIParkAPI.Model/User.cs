using System;

namespace ISIParkAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nif { get; set; }
        public DateTime DataNasc { get; set; }
        public string Genero { get; set; }
        public int Tipo_utilizadorid { get; set; }
        public int Moradaid_morada { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

