using Rabbitmq_Producer.mvc.Domain.Entities;

namespace Rabbitmq_Producer.mvc.Infrastructure.Data.Repositories
{
    public interface IPagamentoRepository
    {
        void SalvarPagamentoConfirmado(Pagamento pagamento);
        
    }
}
