using Microsoft.AspNetCore.Mvc;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

namespace PJ_RESTAURANTE_5TO_CICLO.Controllers
{

    private 

    public class ColaboradorController : Controller
    {

        private IColaborador iColaborador = new ColaboradorRepository();


        

        public async Task<IActionResult> registrarColaborador(Colaborador obj, IFormFile imagen)
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
                                obj.imagen_colaborador = br.ReadBytes((int)st.Length);
                            }
                        }
                    }

                    if (iColaborador.buscar(obj.id_colaborador) != null)
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

            TempData["mensaje"] = mensaje + "LUIS";


            return RedirectToAction("registrarUsuario");
        }
    }
}
