using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using System.Reflection;
using System.Reflection.Emit;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    class OAuthAwareOperation
    {
#if SANDBOX
        protected const string API_ROOT = "http://sandbox-api.geekli.st/v1/";
#else
        protected const string API_ROOT = "http://api.geekli.st/v1/";
#endif
        Client client;

        public OAuthAwareOperation(Client client)
        {
            this.client = client;
        }

        private OAuthRequest GetRequest(Uri uri)
        {
            return client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, uri)
                    .Sign(client.AccessToken.Secret);
        }

        private OAuthRequest GetRequest(Uri uri, int page, int count)
        {
            return client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, uri)
                   .WithParameters(new { page = page, count = count})
                   .Sign(client.AccessToken.Secret);
        }

        private OAuthRequest GetRequest(Uri uri,  object parameter)
        {
            return client.MakeRequest("GET")
                    .ForResource(client.AccessToken.Token, uri)
                    .WithParameters(parameter)
                    .Sign(client.AccessToken.Secret);
        }

        private OAuthRequest PostRequest(Uri uri, string data)
        {
            return client.MakeRequest("POST")
                .WithData(data)
                .ForResource(client.AccessToken.Token, uri)
                .Sign(client.AccessToken.Secret);
        }

        private OAuthRequest PostRequest(Uri uri, object parameters)
        {
            return client.MakeRequest("POST")
                .WithParameters(parameters)
                .ForResource(client.AccessToken.Token, uri)
                .Sign(client.AccessToken.Secret);
        }

        
        private OAuthRequest PostRequest(Uri uri)
        {
            return client.MakeRequest("POST")
                .ForResource(client.AccessToken.Token, uri)
                .Sign(client.AccessToken.Secret);
        }

        protected T Get<T>(string uri)
        {
            var req = GetRequest(new Uri(uri)).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<T>(req);
        }

        protected T Get<T>(string uri, object parameters)
        {
            var req = GetRequest(new Uri(uri), parameters).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<T>(req);
        }

        protected T Get<T>(string uri, int page, int count)
        {
            var req = GetRequest(new Uri(uri), page, count).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<T>(req);
        }

        protected async Task<T> GetAsync<T>(string uri)
        {
            var req = await GetRequest(new Uri(uri)).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<T>(req);
        }

        protected async Task<T> GetAsync<T>(string uri, int page, int count)
        {
            var req = await GetRequest(new Uri(uri), page, count).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<T>(req);
        }

        protected async Task<T> GetAsync<T>(string uri, object parameters)
        {
            var req = await GetRequest(new Uri(uri), parameters).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<T>(req);
        }

        protected T Post<T>(string uri)
        {
            var req = PostRequest(new Uri(uri)).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<T>(req);
        }

        protected T Post<T>(string uri, object parameters)
        {
            var req = PostRequest(new Uri(uri), parameters).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<T>(req);
        }

        protected void Post(string uri)
        {   //result is irgnores, the request will throw an exception in cause of it fails
            var req = PostRequest(new Uri(uri)).ExecuteRequest().Result;
        }

        protected void Post(string uri, object parameters)
        {   //result is irgnores, the request will throw an exception in cause of it fails
            var req = PostRequest(new Uri(uri), parameters).ExecuteRequest().Result;
        }

        protected async Task<T> PostAsync<T>(string uri)
        {
            var req = await PostRequest(new Uri(uri)).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<T>(req);
        }

        protected async Task<T> PostAsync<T>(string uri, object parameters)
        {
            var req = await PostRequest(new Uri(uri), parameters).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<T>(req);
        }

        protected async Task PostAsync(string uri)
        {
            var req = await PostRequest(new Uri(uri)).ExecuteRequest();
        }

        protected async Task PostAsync(string uri, object parameters)
        {
            var req = await PostRequest(new Uri(uri), parameters).ExecuteRequest();
        }

    }
}
