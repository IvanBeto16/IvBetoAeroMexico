using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result UsuarioGetByUsername(string username, string password)
        {
            ML.Result result = new ML.Result();
            //ML.Usuario user = new ML.Usuario();
            try
            {
                using (DL.IvBetoAeroMexicoEntities context = new DL.IvBetoAeroMexicoEntities())
                {
                    var query = (from usuario in context.Usuario
                                 where usuario.Username == username && usuario.Password == password
                                 select new
                                 {
                                     IdUsuario = usuario.IdUsuario,
                                     Username = usuario.Username,
                                     Password = usuario.Password
                                 });
                    if(query != null && query.ToList().Count() > 0)
                    {
                        result.Object = new object();
                        foreach(var item in  query)
                        {
                            ML.Usuario auxiliar = new ML.Usuario();
                            auxiliar.IdUsuario = item.IdUsuario;
                            auxiliar.Username = item.Username;
                            auxiliar.Password = item.Password;

                            result.Object = auxiliar;
                            result.Correct = true;
                        }
                    }
                }
            }catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
