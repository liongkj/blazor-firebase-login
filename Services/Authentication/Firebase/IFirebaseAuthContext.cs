using Firebase.Auth;

namespace Services.Authentication.Firebase
{
    public interface IFirebaseAuthContext
    {
        public FirebaseAuthClient FirebaseClient { get; }
    }
}