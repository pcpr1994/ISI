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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Model
{
    public class Place
    {
        public int Numero_lugar { get; set; }
        public int Setorid_setor { get; set; }
        public int Tipo_lugarn_tipo { get; set; }
        public bool Estado { get; set; }    
        public string Utilizador_Tipo_veiculosmatricula { get; set; }
    }
}
