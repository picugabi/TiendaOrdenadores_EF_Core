using Azure.Messaging.ServiceBus;
using MVC_ComponentesCodeFirst.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVC_ComponentesCodeFirst.Servicios.ComponenteRepository
{
    public class ComponenteApiService :IComponenteRepository
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public ComponenteApiService(HttpClient HttpClient, IConfiguration configuration)
        {
            _httpClient = HttpClient;
            _configuration = configuration;
        }

        public Componente? DameComponente(int id)
        {
            
            var callResponse = _httpClient.GetAsync($"https://localhost:7199/api/componentes/{id}").Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Componente>(response);
        }

        public async void AddComponente(Componente componente)
        {
            var uri = "https://localhost:7199/api/componentes/";
            var myContent = JsonConvert.SerializeObject(componente);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _httpClient.PostAsync(uri, byteContent);
            ServiceBusClient client = new ServiceBusClient(_configuration["BusServiceComponente"]);
            var sender = client.CreateSender(_configuration["QueueName"]);
            ServiceBusMessage message = new ServiceBusMessage($"Creando {buffer}");
            await sender.SendMessageAsync(message);
        }

        public void BorrarComponente(int id)
        {
            _httpClient.DeleteAsync("https://localhost:7199/api/componentes/" + id);
        }

        public List<Componente>? ListaComponentes()
        {
            var callRespone =_httpClient.GetAsync("https://localhost:7199/api/componentes/").Result;
            var response = callRespone.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Componente>>(response);
            if (result == null)
            {
                return new List<Componente>();
            }

            return result;
        }

        public void ActualizarComponente(int id, Componente componente)
        {
            var componenteSerializado = JsonConvert.SerializeObject(componente);
            var buffer = System.Text.Encoding.UTF8.GetBytes(componenteSerializado);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var callResponse = _httpClient.PutAsync($"https://localhost:7199/api/componentes/{id}", byteContent).Result;
            if (!callResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Error en la solicitud HTTPS: {callResponse.StatusCode}");
            }
        }
    }
}
