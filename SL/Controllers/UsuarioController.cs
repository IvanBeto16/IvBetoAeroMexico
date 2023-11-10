using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/Aeromexico/Usuario")]
    public class UsuarioController : ApiController
    {
        [Route("{username}/{password}")]
        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            ML.Result result = BL.Usuario.UsuarioGetByUsername(username, password);
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
