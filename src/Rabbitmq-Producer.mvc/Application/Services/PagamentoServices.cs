using Rabbitmq_Producer.mvc.Application.ExternalServices;
using Rabbitmq_Producer.mvc.Domain.Entities;
using Rabbitmq_Producer.mvc.Infrastructure.Data.Repositories;
using Rabbitmq_Producer.mvc.WebUI.Models;

namespace Rabbitmq_Producer.mvc.Application.Services
{
    public class PagamentoServices : IPagamentoServices
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPagamentoQueue _pagamentoQueue;

        public PagamentoServices(IPagamentoRepository pagamentoRepository, IPagamentoQueue pagamentoQueue)
        {
            _pagamentoRepository = pagamentoRepository;
            _pagamentoQueue = pagamentoQueue;
        }

        public bool ConfirmarPagamento(PagamentoCreateViewModel pagamentocreateViewModel)
        {
            return _pagamentoQueue.ConfirmarPagamento(pagamentocreateViewModel);
        }

        public void SalvarPagamentoConfirmado(PagamentoCreateViewModel pagamentocreateViewModel)
        {
            Pagamento pagamento = new Pagamento
            (
              pagamentocreateViewModel.NomeCompleto,
              pagamentocreateViewModel.Email,
              pagamentocreateViewModel.ComprovantePagamento,
              pagamentocreateViewModel.DataPagamento
            );

            _pagamentoRepository.SalvarPagamentoConfirmado(pagamento);
        }


    }
}
