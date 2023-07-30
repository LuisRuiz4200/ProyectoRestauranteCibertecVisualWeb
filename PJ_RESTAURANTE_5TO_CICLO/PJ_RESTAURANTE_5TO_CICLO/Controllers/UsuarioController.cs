using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

namespace PJ_RESTAURANTE_5TO_CICLO.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuario iUsuario = new UsuarioRepository();
        private ITipoUsuario iTipoUsuario = new TipoUsuarioRepository();
        private IDistrito iDistrito = new DistritoRepository();


        public async Task<IActionResult> listarUsuario()
        {

            return View(await Task.Run(()=>iUsuario.listar()));
        }

        public async Task<IActionResult> registrarUsuario()
        {
            ViewBag.listaTipoUsuario = await Task.Run(()=>new SelectList(iTipoUsuario.listar(),"id_tipo_usuario","des_tipo_usuario"));
            ViewBag.listaDistrito = await Task.Run(() => new SelectList(iDistrito.listar(), "id_distrito", "des_distrito"));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> registrarUsuario(Usuario obj,IFormFile imagen)
        {

            string mensaje = "";

            try
            {
                if (ModelState.IsValid)
                {
                    if (imagen.Length != 0)
                    {
                        using (Stream st = imagen.OpenReadStream())
                        { 
                            using (BinaryReader br = new BinaryReader(st)) 
                            {
                                obj.imagen_usuario = br.ReadBytes((int)st.Length);
                            }
                        }
                    }

                    mensaje = iUsuario.agregar(obj);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            TempData["mensaje"] = mensaje  + "LUIS";


            return RedirectToAction("registrarUsuario");
        }


    }
}
