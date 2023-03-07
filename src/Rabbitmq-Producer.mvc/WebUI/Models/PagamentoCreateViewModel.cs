using System.ComponentModel.DataAnnotations;

namespace Rabbitmq_Producer.mvc.WebUI.Models
{
    public class PagamentoCreateViewModel
    {
        [Required(ErrorMessage ="informe seu nome completo")]
        [MinLength(3,ErrorMessage ="O campo Nome Completo deve conter mais de 3 caracteres.")]
        public string NomeCompleto { get; set; }
        
        [Required(ErrorMessage = "informe seu E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "informe o código do comprovante de pagamento ")]
        public string ComprovantePagamento { get; set; }
        
        [Required(ErrorMessage = "informe A data de pagamento realizado")]
        [DataType(DataType.Date)]
        
        public DateTime DataPagamento { get; set; }

    }
}

