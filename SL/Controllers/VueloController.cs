using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;

namespace SL.Controllers
{
    [RoutePrefix("api/Aeromexico/Vuelo")]
    public class VueloController : ApiController
    {
        [Route("GetVuelos")]
        [HttpGet]
        public IHttpActionResult GetVuelos(DateTime fechaInicio, DateTime fechafin)
        {
            ML.Result result = BL.Vuelo.GetVuelos(fechaInicio, fechafin);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [Route("Reservacion")]
        [HttpPost]
        public IHttpActionResult Reservacion([FromBody]ML.Reserva reserva)
        {
            ML.Result result = BL.Vuelo.ReservaVuelo(reserva.NumeroVuelo, reserva.idPasajero);
            if(result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }

        [Route("GetAllVuelos")]
        [HttpGet]
        public IHttpActionResult GetAllVuelos()
        {
            ML.Result result = BL.Vuelo.GetAllVuelos();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

    }
}
