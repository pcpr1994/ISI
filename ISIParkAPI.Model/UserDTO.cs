/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using System;

namespace ISIParkAPI.Model
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nif { get; set; }
        public DateTime DataNasc { get; set; }
        public string Genero { get; set; }
        public int Tipo_utilizadorid { get; set; }
        public int Moradaid_morada { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
