using System;
using System.Net.Http;
using Newtonsoft.Json;

class Users {
    private HttpClient _client;

    public Users() 
    {
        _client = new HttpClient { 
            BaseAddress = new Uri(Environment.GetEnvironmentVariable("BASE_URL")) 
        };
    }

    public HttpResponseMessage Get(String userId)
    {
        return _client.GetAsync($"users/{userId}").Result;
    }

    public HttpResponseMessage Create(object userData)
    {
        var payload = new StringContent(JsonConvert.SerializeObject(userData));
        return _client.PostAsync("users", payload).Result;
    }
}