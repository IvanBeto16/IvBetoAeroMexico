using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50220/");
                var responseTask = client.GetAsync(client.BaseAddress + $"{username}"+$"{password}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Acceso Autorizado";
                }
                else
                {
                    ViewBag.Message = "Acceso No Autorizado";
                }
            }
            return PartialView("Modal");
        }

    }
}