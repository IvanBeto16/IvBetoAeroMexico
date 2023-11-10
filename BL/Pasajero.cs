using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static ML.Result PasajeroAdd(ML.Pasajero pasajero)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoAeroMexicoEntities context = new DL.IvBetoAeroMexicoEntities())
                {
                    DL.Pasajero passenger = new DL.Pasajero();
                    passenger.IdPasajero = pasajero.IdPasajero;
                    passenger.Nombre = pasajero.Nombre;
                    passenger.Apellidos = pasajero.Apellidos;
                    passenger.NumeroVuelo = pasajero.Vuelo.NumeroVuelo;

                    context.Pasajero.Add(passenger);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetPasajerosByVuelo(string numeroVuelo)
        {
            ML.Result result = new ML.Result();
            using (DL.IvBetoAeroMexicoEntities context = new DL.IvBetoAeroMexicoEntities())
            {
                var query = (from persona in context.Pasajero
                             join vuelo in context.Vuelo on persona.NumeroVuelo equals vuelo.NumeroVuelo
                             where persona.NumeroVuelo == numeroVuelo
                             select new
                             {
                                 IdPasajero = persona.IdPasajero,
                                 Nombre = persona.Nombre,
                                 Apellidos = persona.Apellidos,
                                 NumeroVuelo = persona.NumeroVuelo,
                                 Origen = vuelo.Origen,
                                 Destino = vuelo.Destino,
                                 FechaInicio = vuelo.FechaInicio,
                                 FechaSalida = vuelo.FechaSalida
                             });
                
                if(query != null && query.ToList().Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach(var item in query)
                    {
                        ML.Pasajero passenger = new ML.Pasajero();
                        passenger.Vuelo = new ML.Vuelo();
                        passenger.IdPasajero = item.IdPasajero;
                        passenger.Nombre = item.Nombre;
                        passenger.Apellidos = item.Apellidos;
                        passenger.Vuelo.NumeroVuelo = item.NumeroVuelo;
                        passenger.Vuelo.Origen = item.Origen;
                        passenger.Vuelo.Destino = item.Destino;
                        passenger.Vuelo.FechaInicio = Convert.ToDateTime(item.FechaInicio);
                        passenger.Vuelo.FechaSalida = Convert.ToDateTime(item.FechaSalida);

                        result.Objects.Add(passenger);
                        result.Correct = true;
                    }
                }
                else
                {
                    result.ErrorMessage = "Hubo un error al buscar pasajeros para ese vuelo";
                    result.Correct = false;
                }
            }
            return result;
        }
    }
}
