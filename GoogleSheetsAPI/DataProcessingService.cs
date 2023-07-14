using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoogleSheetsAPI
{
    public class DataProcessingService
    {
        private readonly string _connectionString;

        public DataProcessingService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ProcessJsonData(string jsonData)
        {
            // Convierte el JSON en objetos C# utilizando Newtonsoft.Json
            var data = JsonConvert.DeserializeObject<List<Item>>(jsonData);

            // Conecta a la base de datos utilizando el SqlConnection
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Itera sobre los datos y guárdalos en la base de datos utilizando ADO.NET
                foreach (var item in data)
                {
                    using (var command = new SqlCommand("INSERT INTO YourTable (JEFEDEVENTA, SUPERVISOR, PDV, Fecha, HoraApertura, HoraCierre) VALUES (@JEFEDEVENTA, @SUPERVISOR, @PDV, @Fecha, @HoraApertura, @HoraCierre)", connection))
                    {
                        command.Parameters.AddWithValue("@JEFEDEVENTA", item.JEFEDEVENTA);
                        command.Parameters.AddWithValue("@SUPERVISOR", item.SUPERVISOR);
                        command.Parameters.AddWithValue("@PDV", item.PDV);
                        command.Parameters.AddWithValue("@Fecha", item.Fecha);
                        command.Parameters.AddWithValue("@HoraApertura", item.HoraApertura);
                        command.Parameters.AddWithValue("@HoraCierre", item.HoraCierre);


                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
    }
}
