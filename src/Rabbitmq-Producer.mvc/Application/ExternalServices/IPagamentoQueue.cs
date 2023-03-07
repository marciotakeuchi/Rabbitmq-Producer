using Rabbitmq_Producer.mvc.WebUI.Models;

namespace Rabbitmq_Producer.mvc.Application.ExternalServices
{
    public interface IPagamentoQueue
    {
        bool ConfirmarPagamento(PagamentoCreateViewModel pagamentocreateViewModel);
    }
}
