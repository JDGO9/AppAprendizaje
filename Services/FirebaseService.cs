using System.Net.Http.Json;

namespace Proyect.Services
{
    public class FirebaseService
    {
        private readonly HttpClient _httpClient;

        private const string ApiKey = "AIzaSyBqRH-b2bDKgZEITyVzW37i1WyEP04l-ig";

        public FirebaseService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}";
            var body = new { email, password, returnSecureToken = true };

            var response = await _httpClient.PostAsJsonAsync(url, body);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}";
            var body = new { email, password, returnSecureToken = true };

            var response = await _httpClient.PostAsJsonAsync(url, body);
            return response.IsSuccessStatusCode;
        }
    }
}