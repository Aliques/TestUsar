using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestTaskUsar.Core.Interfaces.Serivces;

namespace TestTaskUsar.Core.Services
{
    public class HttpClientMessageCrudService : IHttpClientServiceImplementation
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _path = "message";
        private readonly JsonSerializerOptions _options;

        public HttpClientMessageCrudService()
        {
            _httpClient.BaseAddress = new Uri("https://testtaskusarapi20220328022649.azurewebsites.net");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<Message> Create(Message message)
        {
            var messageForCreation = JsonSerializer.Serialize(message);
            var request = new HttpRequestMessage(HttpMethod.Post, _path);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(messageForCreation, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Message>(content, _options);
        }

        public async Task<IEnumerable<Message>> Get()
        {
            var response = await _httpClient.GetAsync(_path);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var messages = JsonSerializer.Deserialize<List<Message>>(content, _options);

            return messages;
        }
    }
}
