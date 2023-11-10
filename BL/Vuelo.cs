using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BL
{
    public class Vuelo
    {
        //Metodos realizados con LINQ
        public static ML.Result GetVuelos(DateTime? fechainicio, DateTime? fechafin)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoAeroMexicoEntities context = new DL.IvBetoAeroMexicoEntities())
                {
                    var query = (from vuelo in context.Vuelo
                                 where vuelo.FechaInicio == fechainicio & vuelo.FechaSalida == fechafin
                                 select new
                                 {
                                     NumeroVuelo = vuelo.NumeroVuelo,
                                     Origen = vuelo.Origen,
                                     Destino = vuelo.Destino,
                                     FechaInicio = vuelo.FechaInicio,
                                     FechaFin = vuelo.FechaSalida
                                 });
                    if (query != null && query.ToList().Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();
                            vuelo.NumeroVuelo = item.NumeroVuelo;
                            vuelo.Origen = item.Origen;
                            vuelo.Destino = item.Destino;
                            vuelo.FechaInicio = Convert.ToDateTime(item.FechaInicio);
                            vuelo.FechaSalida = Convert.ToDateTime(item.FechaFin);

                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.ErrorMessage = "No se encontraron vuelos en los parametros especificados";
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result GetAllVuelos()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoAeroMexicoEntities context = new DL.IvBetoAeroMexicoEntities())
                {
                    var query = (from vuelo in context.Vuelo
                                 select new
                                 {
                                     NumeroVuelo = vuelo.NumeroVuelo,
                                     Origen = vuelo.Origen,
                                     Destino = vuelo.Destino,
                                     FechaInicio = vuelo.FechaInicio,
                                     FechaFin = vuelo.FechaSalida
                                 });
                    if (query != null && query.ToList().Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();
                            vuelo.NumeroVuelo = item.NumeroVuelo;
                            vuelo.Origen = item.Origen;
                            vuelo.Destino = item.Destino;
                            vuelo.FechaInicio = Convert.ToDateTime(item.FechaInicio);
                            vuelo.FechaSalida = Convert.ToDateTime(item.FechaFin);

                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.ErrorMessage = "No se encontraron vuelos registrados";
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        

        public static ML.Result ReservaVuelo(string numeroVuelo, int idPasajero)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (DL.IvBetoAeroMexicoEntities context = new DL.IvBetoAeroMexicoEntities())
                {
                    ML.Pasajero pasajero = new ML.Pasajero();
                    pasajero.Vuelo = new ML.Vuelo();
                    pasajero.IdPasajero = idPasajero;

                    ML.Vuelo vuelo = new ML.Vuelo();
                    vuelo.Pasajeros = new List<ML.Pasajero>();

                    var query = (from vuelos in context.Vuelo
                                 where vuelos.NumeroVuelo == numeroVuelo
                                 select new
                                 {
                                     NumeroVuelo = vuelos.NumeroVuelo,
                                     Origen = vuelos.Origen,
                                     Destino = vuelos.Destino,
                                     FechaInicio = vuelos.FechaInicio,
                                     FechaSalida = vuelos.FechaSalida,
                                 });
                    if(query != null && query.ToList().Count > 0)
                    {
                        foreach(var item in query)
                        {
                            vuelo.NumeroVuelo = item.NumeroVuelo;
                            vuelo.Origen = item.Origen;
                            vuelo.Destino = item.Destino;
                            vuelo.FechaInicio = Convert.ToDateTime(item.FechaInicio);
                            vuelo.FechaSalida = Convert.ToDateTime(item.FechaSalida);
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el vuelo solicitado";
                    }

                    var consulta = (from pass in context.Pasajero
                                    where pass.NumeroVuelo == numeroVuelo && pass.IdPasajero == idPasajero
                                    select new
                                    {
                                        IdPasajero = pass.IdPasajero,
                                        Nombre = pass.Nombre,
                                        Apellidos = pass.Apellidos,
                                        NumeroVuelo = pass.NumeroVuelo
                                    });
                    if(consulta != null && consulta.ToList().Count > 0)
                    {
                        foreach(var item in consulta)
                        {
                            pasajero.IdPasajero = item.IdPasajero;
                            pasajero.Nombre = item.Nombre;
                            pasajero.Apellidos = item.Apellidos;
                            pasajero.Vuelo.NumeroVuelo = item.NumeroVuelo;

                            vuelo.Pasajeros.Add(pasajero);
                        }
                        
                        result.Objects.Add(vuelo);
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El pasajero ya esta asignado para otro vuelo";
                    }
                    result.Correct = true;
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
