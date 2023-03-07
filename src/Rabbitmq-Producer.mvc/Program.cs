using Rabbitmq_Producer.mvc.Application.ExternalServices;
using Rabbitmq_Producer.mvc.Application.Services;
using Rabbitmq_Producer.mvc.Infrastructure.Data.Repositories;

namespace Rabbitmq_Producer.mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //IoC
            builder.Services.AddScoped<IPagamentoServices, PagamentoServices>();
            builder.Services.AddScoped<IPagamentoQueue, PagamentoQueue>();
            builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Pagamento/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pagamento}/{action=Index}/{id?}");

            app.Run();
        }
    }
}