namespace Core.Notificador
{
    public sealed class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public void Notificar(Notificacao notificacao)
            => _notificacoes.Add(notificacao);

        public void Notificar(string mensagem)
            => _notificacoes.Add(new Notificacao(mensagem));

        public void NotificarMensagemErroInterno()
            => _notificacoes.Add(new Notificacao("Ocorreu um erro inesperado. Por favor, entre em contato com o suporte."));

        public List<Notificacao> ObterNotificacoes()
            => _notificacoes;

        public bool TemNotificacao()
            => _notificacoes.Any();
    }
}
