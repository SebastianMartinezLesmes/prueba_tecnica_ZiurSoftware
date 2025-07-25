using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class DocumentoService
    {
        private readonly HttpClient _httpClient;

        public DocumentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Documento>> ObtenerDocumentosAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
                "https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", 
                "ae8bad44-7348-11ee-b962-0242ac120002");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Documento>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
