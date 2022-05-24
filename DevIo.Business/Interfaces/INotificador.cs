using DevIO.Business.Notificacoes;

namespace DevIO.Business.Interfaces
{
    public interface INotificador
    {
        //valida se tem notificação, retornando se tem true ou false
        bool TemNotificacao();

        //obter notificações, retornando uma lista do mesmo.
        List<Notificacao> ObterNotificacoes();
        //manipular quando uma notificação for lançada
        void Handle(Notificacao notificacao);
    }
}
