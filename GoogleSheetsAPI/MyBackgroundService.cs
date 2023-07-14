using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace GoogleSheetsAPI
{
    public class MyBackgroundService:BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceProvider _services;

        public MyBackgroundService(IHttpClientFactory httpClientFactory, IServiceProvider services)
        {
            _httpClientFactory = httpClientFactory;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scope = _services.CreateScope())
                {
                    try
                    {
                        // Obtén una instancia del cliente HttpClient desde el factory
                        var httpClient = _httpClientFactory.CreateClient();

                        // Realiza la llamada al endpoint GET de tu API
                        var response = await httpClient.GetAsync("https://localhost:44371/api/Items");

                        // Aquí puedes procesar la respuesta si es necesario
                        if (response.IsSuccessStatusCode)
                        {
                            // La respuesta fue exitosa
                            var json = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(json); // Imprime el JSON en la consola
                        }
                        else
                        {
                            // La respuesta no fue exitosa, maneja el error según corresponda
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de la excepción
                        Console.WriteLine($"Ocurrió un error: {ex.Message}");
                        // Otras acciones de manejo del error, si es necesario
                    }

                    // Espera 3 minutos antes de realizar la próxima llamada
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

                }
            }
        }
    }
}
