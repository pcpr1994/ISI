using System;

namespace ISIParkAPI.Model
{
    public class History
    {
        public int ID { get; set; }
        //public DateTime Dia { get; set; }
        public DateTime Hora_entrada { get; set; }
        public DateTime Hora_saida { get; set; }
        public int Lugarnumero_lugar { get; set; }
    }
}
