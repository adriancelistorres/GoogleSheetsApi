using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.IO;

namespace GoogleSheetsAPI
{
    public class GoogleSheetsHelper
    {
        public SheetsService Service { get; set; }
        const string APPLICATION_NAME = "ESTATUS APERTURA PDV";
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        public GoogleSheetsHelper()
        {
            InitializeService();
        }

        private void InitializeService()
        {
            try
            {
                var credential = GetCredentialsFromFile();
            Service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPLICATION_NAME
            });
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine($"Ocurrió un error al inicializar el servicio de Google Sheets: {ex.Message}");
                // Otras acciones de manejo del error, si es necesario
            }
        }

        private GoogleCredential GetCredentialsFromFile()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            return credential;
        }
    }
}
