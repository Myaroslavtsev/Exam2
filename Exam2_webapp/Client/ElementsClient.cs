using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using View;
using System.Threading;
using System.Threading.Tasks;
using View.Resistors;
using System.Net.Http;
using System.Text.Json;

namespace Exam2_webapp.Client
{
    public sealed class ElementsClient : IElementsClient
    {
        private readonly HttpClient httpClient;

        public ElementsClient(string baseUrl) // use https://localhost:5001 for API tests
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }
        
        // Post("")
        public async Task<Resistor> CreateResistorAsync(ResistorCreateInfo createInfo)
        {
            var contentString = JsonSerializer.Serialize(createInfo);
            var buffer = System.Text.Encoding.UTF8.GetBytes(contentString);
            var byteContent = new ByteArrayContent(buffer);
            var response = await this.httpClient.PostAsync("/resistors", byteContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Resistor>(content);
            }
            ThrowExceptionOnUnsuccessfulRequest(response);
            return null;
        }

        // Get("{id}")
        public async Task<Resistor> GetResistorAsync(string id)
        {
            var response = await this.httpClient.GetAsync($"/resistors/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Resistor>(content);                
            }
            ThrowExceptionOnUnsuccessfulRequest(response);
            return null;
        }

        // Get("")
        public async Task<Resistor[]> SearchResistorAsync(ResistorSearchInfo searchInfo)
        {
            // example of request string:
            // https://localhost:5001/resistors?Resistance=10000&MaxAccuracy=0.5&MinPower=0.01&MinQuantity=0&Limit=10
            var requestString = string.Empty;

            if (searchInfo.Resistance != null)
                requestString += $"&Resistance={searchInfo.Resistance}";

            if (searchInfo.MinPower != null)
                requestString += $"&MinPower={searchInfo.MinPower}";

            if (searchInfo.MaxAccuracy != null)
                requestString += $"&MaxAccuracy={searchInfo.MaxAccuracy}";

            if (searchInfo.MinQuantity != null)
                requestString += $"&MinQuantity={searchInfo.MinQuantity}";

            if (!string.IsNullOrEmpty(searchInfo.Material))
                requestString += $"&Material={searchInfo.Material}";

            if (!string.IsNullOrEmpty(searchInfo.Manufacturer))
                requestString += $"&Manufacturer={searchInfo.Manufacturer}";

            if (searchInfo.Offset != null)
                requestString += $"&Offset={searchInfo.Offset}";

            if (searchInfo.Limit != null)
                requestString += $"&Limit={searchInfo.Limit}";
            
            var response = await this.httpClient.GetAsync($"/resistors?{requestString}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Resistor[]>(content);
            }
            ThrowExceptionOnUnsuccessfulRequest(response);
            return null;
        }

        // Delete("{id}")
        public async Task DeleteResistorAsync(string id)
        {
            await this.httpClient.DeleteAsync($"/resistors/{id}");
        }

        // Patch("{id}")
        public async Task PatchResistorAsync(string id, ResistorUpdateInfo updateInfo)
        {
            var contentString = JsonSerializer.Serialize(updateInfo);
            var buffer = System.Text.Encoding.UTF8.GetBytes(contentString);
            var byteContent = new ByteArrayContent(buffer);
            await this.httpClient.PatchAsync($"/resistors/{id}", byteContent);
        }

        private void ThrowExceptionOnUnsuccessfulRequest(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new HttpRequestException("Not found");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new HttpRequestException("Bad request");
            throw new HttpRequestException("Other http exception");
        }
    }
}