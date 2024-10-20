using AuthApp.Core.Contracts;
using AuthApp.Core.Models;
using AuthApp.DAL.NamingPolicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthApp.DAL.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Регистрация пользователя
        public async Task<bool> RegisterUserAsync(User user)
        {
            string userJson = JsonSerializer.Serialize(
                user, 
                options: new JsonSerializerOptions() { 
                    PropertyNamingPolicy = new LowerCaseNamingPolicy() 
                });
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var contentStr = await content.ReadAsStringAsync();

            var response = await _httpClient.PostAsync("/v2/user", content);
            return response.IsSuccessStatusCode;
        }

        // Авторизация пользователя
        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _httpClient.GetAsync($"/v2/user/login?username={username}&password={password}");
            return response.IsSuccessStatusCode;
        }

        // Разлогин пользователя
        public async Task<bool> LogoutAsync()
        {
            var response = await _httpClient.GetAsync("/v2/user/logout");
            return response.IsSuccessStatusCode;
        }

        // Получение данных пользователя по username
        public async Task<User> GetUserByLoginAsync(string username)
        {
            var response = await _httpClient.GetAsync($"/v2/user/{username}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(jsonResponse, options: new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new LowerCaseNamingPolicy()
            });

            return user ?? new User();
        }
    }

}
