
using Firebase.Auth;

using System;

namespace Services.Authentication
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public Exception Error { get; set; }
        public User User { get; set; }
    }
}