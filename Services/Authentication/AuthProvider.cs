
using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;

        public AuthProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Get token and username from local storage
            var savedToken = await localStorage.GetItemAsync<string>("authToken");
            var userID = await localStorage.GetItemAsync<string>("userID");
            var roles = await localStorage.GetItemAsync<List<string>>("roles");
            //TODO validate token
            //if null, not logged in
            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            //Add role
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userID)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Set token for HTTP authentication
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
            // return authentication information
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "User")));

        }

        public async Task SetUserAsAuthenticated(string userId, string authToken, List<string> roles = null)
        {
            await localStorage.SetItemAsync("userId", userId);
            await localStorage.SetItemAsync("authToken", authToken);
            if (roles != null)
            {
                await localStorage.SetItemAsync("roles", roles);
            }
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        }

        public async Task SetUserAsLoggedOut()
        {
            await localStorage.RemoveItemAsync("userID");
            await localStorage.RemoveItemAsync("authToken");
            await localStorage.RemoveItemAsync("roles");
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
