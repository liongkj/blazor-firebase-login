using Firebase.Auth;

using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Authentication.Firebase
{
    public class FirebaseSetting : IFirebaseSetting
    {
        public string ApiKey { get; set; }
        public string AuthDomain { get; set; }
    }
}
