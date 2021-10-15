using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication8.Model;

namespace WebApplication8.Services
{
    public class SpotifyServices : ISpotifyServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuraiton;
        public SpotifyServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuraiton = configuration;
        }
        public async Task<string> GetToken(string clientId, string clientSecret, string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                {"grant_type", "authorization_code"},
                {"code", code },
                {"redirect_uri","https://localhost:44322/api/Authorized"}
            });

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responeStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responeStream);
            return authResult.access_token;
        }
    }
}
