using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Models;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

namespace PJ_RESTAURANTE_5TO_CICLO.Controllers
{
    public class PedidoController : Controller
    {
        private IPedido iPedido = new PedidoRepository();
        private IUsuario iUsuario = new UsuarioRepository();
        private IDirentrega_Usuario iDirentrega_Usuario = new Direntrega_UsuarioRepository();
        private IColaborador iColaborador = new ColaboradorRepository();
        
        public async Task<IActionResult> listarPedido()
        {
            return View(await Task.Run(()=>iPedido.listar()));
        }

        public async Task<IActionResult> resgistrarPedido()
        {
            Pedido obj = new Pedido();
            obj.id_pedido = 1;
            obj.fechareg_pedido = DateTime.Now;
            obj.fechaact_pedido = DateTime.Now;
            obj.estado_pedido = "REGISTRADO";

            ViewBag.listaTipoUsuario = await Task.Run(() => new SelectList(iDirentrega_Usuario.listar(), "id_tipo_usuario", "des_tipo_usuario"));
            ViewBag.listaDistrito = await Task.Run(() => new SelectList(iColaborador.listar(), "id_colaborador", "nom_colaborador"));

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> registrarPedido(Pedido obj)
        {
            return RedirectToAction("registrarPedido");
        }
    }
}
