using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rabbitmq_Producer.mvc.Application.Services;
using Rabbitmq_Producer.mvc.WebUI.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rabbitmq_Producer.mvc.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly IPagamentoServices _pagamentoServices;

        public PagamentoController(IPagamentoServices pagamentoServices)
        {
            _pagamentoServices = pagamentoServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["pagamentos"] == null)
            {
                TempData["pagamentos"] = JsonSerializer.Serialize(new List<PagamentoViewModel>());
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(PagamentoCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _pagamentoServices.ConfirmarPagamento(model);

                TempData["message"] = "informação de confirmação de pagamento enviado. Logo voce receberá um e-mail de confirmação, liberando as aulas do treinamento.";

                TempData["pagamentos"] = JsonSerializer.Serialize(AdicionarPagamento(model));
            }
            catch (Exception e)
            {
                TempData["messageError"] = $"Erro ao enviar as informações. Tente mais tarde. \n Informações do erro: {e.Message} ";
                return View(model);
            }

            return RedirectToAction("Index", "Pagamento");
        }

        private List<PagamentoViewModel> AdicionarPagamento(PagamentoCreateViewModel model)
        {
            List<PagamentoViewModel> pagamentos;// = new List<PagamentoViewModel>();

            if (TempData["pagamentos"] != null)
                pagamentos = JsonSerializer.Deserialize<List<PagamentoViewModel>>(TempData["pagamentos"].ToString());
            else
                pagamentos = new List<PagamentoViewModel>();

            PagamentoViewModel pagamentoViewModel = model;
            pagamentos.Add(pagamentoViewModel);

            return pagamentos;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}