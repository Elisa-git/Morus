using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Notificador
{
    public interface INotificador
    {
        List<Notificacao> ObterNotificacoes();
        bool TemNotificacao();
        void Notificar(Notificacao notificacao);
        void Notificar(string mensagem);
        void NotificarMensagemErroInterno();
    }
}
