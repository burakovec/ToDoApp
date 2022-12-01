using System.Net.Http.Headers;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using ToDoApp.Client.Blazor.ViewModels;

using System.Net.Http.Json;

using ToDoApp.Application.User.Commands;
using ToDoApp.Application.User.Queries;

namespace ToDoApp.Client.Blazor.Services
{


    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<string> Register(RegisterModel registerModel)
        {
            var postTask = await _httpClient.PostAsJsonAsync("api/account/register", new RegisterUserCommand { Email = registerModel.Email, Password = registerModel.Password });
            var result = await postTask.Content.ReadAsStringAsync();
            return result;
        }

        // PostJsonAsync throws an error when reading string result - this is why I switched to PostAsync
        public async Task<string> Login(LoginModel loginModel)
        {
            var tokenTask = await _httpClient.PostAsJsonAsync("api/account/login", new GetTokenQuery { Username = loginModel.Email, Password = loginModel.Password });
            var token = await tokenTask.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(token))
            {
                return token;
            }

            await _localStorage.SetItemAsync("authToken", token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}