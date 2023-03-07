using System.ComponentModel.DataAnnotations;

namespace Rabbitmq_Producer.mvc.WebUI.Models
{
    public class PagamentoViewModel
    {
        public PagamentoViewModel(string nomeCompleto, string email, string comprovantePagamento, DateTime dataPagamento, ESituacao situacao)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            ComprovantePagamento = comprovantePagamento;
            DataPagamento = dataPagamento;
            Situacao = situacao;
        }

        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string ComprovantePagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public ESituacao Situacao { get; set; }

        public static implicit operator PagamentoViewModel(PagamentoCreateViewModel pagamentoCreateVM)
                => new PagamentoViewModel(pagamentoCreateVM.NomeCompleto, pagamentoCreateVM.Email, pagamentoCreateVM.ComprovantePagamento, pagamentoCreateVM.DataPagamento, ESituacao.Pendente);
    }

    public enum ESituacao
    {
        Pendente,
        Reprovado,
        Aprovado
    }
}
