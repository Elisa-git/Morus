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
