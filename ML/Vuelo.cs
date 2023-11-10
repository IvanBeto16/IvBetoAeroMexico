using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Vuelo
    {
        public string NumeroVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaSalida { get; set; }

        //public List<ML.Vuelo> Vuelos { get; set; }
        public List<ML.Pasajero> Pasajeros { get; set; }

    
    }
}
