namespace Rabbitmq_Producer.mvc.Domain.Entities
{
    public class Pagamento
    {
        public Pagamento(string nomeCompleto, string email, string comprovantePagamento, DateTime dataPagamento)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            ComprovantePagamento = comprovantePagamento;
            DataPagamento = dataPagamento;
        }
                
        public int PagamentoID { get;  set; }
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public string ComprovantePagamento { get; private set; }
        public DateTime DataPagamento { get; private set; }
    
       
    }
}
