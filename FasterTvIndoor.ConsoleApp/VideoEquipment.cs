using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FasterTvIndoor.ConsoleApp
{
    public class VideoEquipment
    {
        public void UpdateStatusVideoEquipment()
        {
            
            var client = new HttpClient();

            //Chama o end point
            //client.BaseAddress = new Uri("http://localhost:4002/");
            client.BaseAddress = new Uri("http://www.fastertecnologia.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Chama o métodp HTTP GET para que o status dos vídeos sejam atualizados
            HttpResponseMessage response = client.GetAsync("api/webjob/updatestatusvideo").Result;

        }
    }
}
