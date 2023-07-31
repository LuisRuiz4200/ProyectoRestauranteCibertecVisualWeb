using Microsoft.AspNetCore.Mvc;
using PJ_RESTAURANTE_5TO_CICLO.Interface;
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
            PedidoController obj = new Pedido();
        }
    }
}
