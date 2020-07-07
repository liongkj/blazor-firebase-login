using Firebase.Auth;

using Microsoft.AspNetCore.Components.Authorization;

using System.Threading.Tasks;

namespace Services.Authentication.Firebase
{
    public class FirebaseAuthService : IAuthService
    {
        private readonly AuthenticationStateProvider AuthenticationStateProvider;
        private readonly IFirebaseAuthClient firebaseAuthClient;

        public FirebaseAuthService(AuthenticationStateProvider authenticationStateProvider, IFirebaseAuthContext firebaseAuthcontext)
        {
            AuthenticationStateProvider = authenticationStateProvider;
            this.firebaseAuthClient = firebaseAuthcontext.FirebaseClient;
        }


        public async Task<LoginResult> LoginAsync(LoginModel loginModel)
        {
            try
            {
                var userCredential = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(loginModel.UserId, loginModel.Password);
                var res = new LoginResult()
                {
                    IsSuccess = true,
                    User = userCredential.User
                };
                var idToken = await res.User.GetIdTokenAsync();
                await ((AuthProvider)AuthenticationStateProvider).SetUserAsAuthenticated(loginModel.UserId, idToken);
                return res;
            }
            catch (FirebaseAuthException e)
            {
                return new LoginResult()
                {
                    IsSuccess = false,
                    Error = e
                };
            }
        }

        public async Task LogoutAsync()
        {
            await firebaseAuthClient.SignOutAsync();
            await ((AuthProvider)AuthenticationStateProvider).SetUserAsLoggedOut();
        }
    }
}
