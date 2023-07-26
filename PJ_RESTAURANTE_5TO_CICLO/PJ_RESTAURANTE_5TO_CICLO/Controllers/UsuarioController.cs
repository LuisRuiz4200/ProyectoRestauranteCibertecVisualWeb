using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

namespace PJ_RESTAURANTE_5TO_CICLO.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuario iUsuario = new UsuarioRepository();

        public async Task<IActionResult> registrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> registrarUsuario(Usuario obj,IFormFile imagen)
        {
            string mensaje = "";

            if (ModelState.IsValid)
            {
                byte[] data = null; 

                if (imagen != null)
                {

                    data = new byte[imagen.Length];
                }

                // mensaje = imagen.ToString();
                obj.imagen_usuario= data;
                mensaje = iUsuario.agregar(obj);
            }

            TempData["mensaje"] = mensaje;


            return View("registrarUsuario");
        }
    }
}
