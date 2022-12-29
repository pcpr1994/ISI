﻿namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of parking sensors 
    /// </summary>
    public class ParkingSensor
    {
        /// <summary>
        /// ID_Morada is a variable that saves the id
        /// </summary>
        public int ID_Morada { get; set; }

        /// <summary>
        /// Rua is a variable that saves the road
        /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// NPorta is a variable that saves the door number for each house
        /// </summary>
        public int NPorta { get; set; }

        /// <summary>
        /// CP4 ia a variable that saves the first four numbers of postal code
        /// </summary>
        public int CP4 { get; set; }

        /// <summary>
        /// CP3 ia a variable that saves the seconds three numbers of postal code
        /// </summary>
        public int CP3 { get; set; }

        /// <summary>
        /// Localidade is a variable that saves the name of location
        /// </summary>
        public string Localidade { get; set; }

        /// <summary>
        /// Cidade is a variable that saves the name of each city
        /// </summary>
        public string Cidade { get; set; }
    }
}
