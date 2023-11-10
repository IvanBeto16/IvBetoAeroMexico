using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/Aeromexico/Pasajero")]
    public class PasajeroController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult PasajeroAdd([FromBody] ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.PasajeroAdd(pasajero);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("GetPasajeros")]
        [HttpGet]
        public IHttpActionResult GetPasajeros(string numeroVuelo)
        {
            ML.Result result = BL.Pasajero.GetPasajerosByVuelo(numeroVuelo);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
