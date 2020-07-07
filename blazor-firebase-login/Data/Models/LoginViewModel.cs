
using Microsoft.AspNetCore.Components;

using Services.Authentication;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_firebase_login.Data.Models
{
    public class LoginViewModel : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IAuthService AuthService { get; set; }

        public LoginModel LoginModel { get; set; } = new LoginModel();
        public string ErrorMessage { get; set; }
        public bool IsLoading { get; set; } = false;

        public async Task SubmitAsync()
        {
            IsLoading = true;
            var model = new Services.Authentication.LoginModel() { UserId = LoginModel.UserID, Password = LoginModel.Password };
            var result = await AuthService.LoginAsync(model);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                ErrorMessage = "Login Failed";
            }
            IsLoading = false;
        }
    }
}
