using Rabbitmq_Producer.mvc.WebUI.Models;

namespace Rabbitmq_Producer.mvc.Application.Services
{
    public interface IPagamentoServices
    {
        void SalvarPagamentoConfirmado(PagamentoCreateViewModel pagamentocreateViewModel);
        bool ConfirmarPagamento(PagamentoCreateViewModel pagamentocreateViewModel);
    }
}
