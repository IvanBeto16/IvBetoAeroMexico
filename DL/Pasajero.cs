//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pasajero
    {
        public int IdPasajero { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroVuelo { get; set; }
    
        public virtual Vuelo Vuelo { get; set; }
    }
}
