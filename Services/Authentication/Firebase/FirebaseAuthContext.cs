using Firebase.Auth;
using Firebase.Auth.Providers;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication.Firebase
{
    public class FirebaseAuthContext : IFirebaseAuthContext
    {
        public FirebaseAuthClient FirebaseClient { get; }
        public FirebaseAuthContext(IFirebaseSetting setting)
        {
            FirebaseAuthConfig config;
            try
            {
                config = new FirebaseAuthConfig
                {
                    ApiKey = setting.ApiKey,
                    AuthDomain = setting.AuthDomain,
                    Providers = new FirebaseAuthProvider[]
                   {
                    // Add and configure individual providers
                    //new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
               },

                };
            }
            catch (Exception e)
            {
                throw e;
            }
            FirebaseClient = new FirebaseAuthClient(config);
        }






    }
}
