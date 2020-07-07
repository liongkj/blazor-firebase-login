# Blazor server side app with Firebase Authentication Dependency Injection code

     To run this solution, clone this repo and build the solution, input your firebase project info in appsettings.json

# Library used

1. [firebase-authentication-dotnet](https://github.com/step-up-labs/firebase-authentication-dotnet/tree/feature/v4) - alpha2
2. Same as blog post below

### Credits to

1. [@nobu17](https://qiita.com/nobu17/items/91c96ede1bd043fe1373#%E3%81%BE%E3%81%A8%E3%82%81)
   Github: [Source Code](https://github.com/nobu17/BlazorAuthTest)

---

Codes

1. App settings

```json
"FirebaseSetting": {
    "apiKey": "AIza",
    "authDomain": "",
    "databaseURL": "",
    "projectId": "",
    "storageBucket": "",
    "messagingSenderId": "",
    "appId": ""
  }
```

2. Services module
3. Startup.cs

```cs
public void ConfigureServices(IServiceCollection services)
        {
            // ...
//Firebase setting
            services.AddHttpClient<AuthenticationStateProvider, AuthProvider>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.Configure<FirebaseSetting>(Configuration.GetSection(nameof(FirebaseSetting)));
            services.AddSingleton<IFirebaseSetting>(sp => sp.GetRequiredService<IOptions<FirebaseSetting>>().Value);
            services.AddScoped<IFirebaseAuthContext, FirebaseAuthContext>();
            services.AddScoped<IAuthService, FirebaseAuthService>();
```
