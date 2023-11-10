using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pasajero
    {
        public int IdPasajero { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroVuelo { get; set; }
        public Vuelo Vuelo { get; set; }

        //public List<Pasajero> Pasajeros { get; set; }
    }
}
