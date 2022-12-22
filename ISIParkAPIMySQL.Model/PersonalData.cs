using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPIMySQL.Model
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
        public DateTime DataNasc { get; set; }
        public string Genero { get; set; }
        public string TipoUtilizador { get; set; }
        public bool Pagamento { get; set; }

    }
}
