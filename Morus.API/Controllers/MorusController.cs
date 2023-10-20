using Core.Notificador;
using Microsoft.AspNetCore.Mvc;

namespace Morus.API.Controllers
{
    public abstract class MorusController : ControllerBase
    {
        protected readonly INotificador _notificador;
        public MorusController(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected ActionResult CustomResponse(int statusCode, bool success, object? data = null)
        {
            return StatusCode(statusCode, new
            {
                success = success,
                data = data,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }
    }
}
