using Microsoft.VisualBasic;
using System;

namespace ISIParkAPI.Model
{
    public class PersonalData
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public int CP4 { get; set; }
        public int CP3 { get; set; }
        public string Rua { get; set; }
        public int Contacto { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataNasc{ get; set; }
        public string Genero { get; set; }
        public string Tipo_Utilizador { get; set; }
        public bool Pagamento { get; set; }

    }
}
