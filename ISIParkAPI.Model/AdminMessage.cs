using System;

namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of AdminMessage
    /// </summary>
    public class AdminMessage
    {
        /// <summary>
        /// ID_Mensagem is a variable that saves the id
        /// </summary>
        public int Id_Mensagem { get; set; }

        /// <summary>
        /// Descricao is a variable that saves the content of each message
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data is a variable that saves the date of each message
        /// </summary>
        public DateTime Data { get; set; }
    }
}
