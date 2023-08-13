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
            Usuario obj = new Usuario();
            obj.id_usuario = 1;
            obj.fechareg_usuario = DateTime.Now;
            obj.fechaact_usuario = DateTime.Now;
            obj.estado_usuario = "REGISTRADO";

            ViewBag.listaTipoUsuario = await Task.Run(()=>new SelectList(iTipoUsuario.listar(),"id_tipo_usuario","des_tipo_usuario"));
            ViewBag.listaDistrito = await Task.Run(() => new SelectList(iDistrito.listar(), "id_distrito", "des_distrito"));

            return View(obj);
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

                    if (iUsuario.buscar(obj.id_usuario) != null)
                    {
                        mensaje = await Task.Run(() => iUsuario.editar(obj));
                    }
                    else 
                    {
                        mensaje = await Task.Run(() => iUsuario.agregar(obj));
                    }

                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            TempData["mensaje"] = mensaje ;


            return RedirectToAction("registrarUsuario");
        }


        public async Task<IActionResult> editarUsuario(int id)
        {
            Usuario? obj  =  await Task.Run(()=> iUsuario.buscar(id));


            ViewBag.listaTipoUsuario = await Task.Run(() => new SelectList(iTipoUsuario.listar(), "id_tipo_usuario", "des_tipo_usuario",obj.id_tipo_usuario));
            ViewBag.listaDistrito = await Task.Run(() => new SelectList(iDistrito.listar(), "id_distrito", "des_distrito",obj.id_distrito));

            return View("registrarUsuario",obj);
        }

        public async Task<IActionResult> eliminarUsuario(int id)
        {

            TempData["mensaje"]= await Task.Run(() => iUsuario.eliminar(id));

            return RedirectToAction("listarUsuario");
        }

    }
}
