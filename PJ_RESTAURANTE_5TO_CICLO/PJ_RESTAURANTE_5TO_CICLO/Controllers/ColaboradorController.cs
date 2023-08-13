using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

namespace PJ_RESTAURANTE_5TO_CICLO.Controllers
{

    public class ColaboradorController : Controller
    {

        private IColaborador iColaborador = new ColaboradorRepository();
        private ITipoColaborador iTipoColaborador = new TipoColaboradorRepository();


        public async Task<IActionResult> listarColaborador()
        { 

            return View(await Task.Run(()=>iColaborador.listar()));
        }

        public async Task<IActionResult> registrarColaborador()
        {
            Colaborador obj = new Colaborador();

            obj.id_colaborador = 1;
            obj.fechareg_colaborador = DateTime.Now;
            obj.fechaact_colaborador = DateTime.Now;
            obj.estado_colaborador = "REGISTRADO";

            ViewBag.listaTipoColaborador = await Task.Run(()=> new SelectList(iTipoColaborador.listar(),"id_tipo_colaborador","des_tipo_colaborador"));

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> registrarColaborador(Colaborador obj, IFormFile imagen)
        {
            string mensaje = "";
            Stream? st = null;
            BinaryReader? br = null;

            try
            {
                if (ModelState.IsValid)
                {
                    if (imagen.Length != 0)
                    {
                        st = imagen.OpenReadStream();
                        br = new BinaryReader(st);

                        obj.imagen_colaborador = br.ReadBytes((int)st.Length);
                    }

                    if (iColaborador.buscar(obj.id_colaborador)!=null)
                    {
                        mensaje = await Task.Run(() => iColaborador.editar(obj));
                    }
                    else
                    {
                        mensaje = await Task.Run(() => iColaborador.agregar(obj));
                    }

                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            TempData["mensaje"] = mensaje ;


            return RedirectToAction("registrarColaborador");
        }


        public async Task<IActionResult> editarColaborador(int id)
        {
            Colaborador? obj = iColaborador.buscar(id);

            ViewBag.listaTipoColaborador = await Task.Run(() => new SelectList(iTipoColaborador.listar(), "id_tipo_colaborador", "des_tipo_colaborador",obj.id_tipo_colaborador));

            return View("registrarColaborador",obj);
        }

        public IActionResult eliminarColaborador()
        {


            return View();
        }
    }
}
