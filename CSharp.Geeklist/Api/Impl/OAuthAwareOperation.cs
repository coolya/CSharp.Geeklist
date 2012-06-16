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
        protected const string API_ROOT = "http://sandbox-api.geekli.st/v1/";
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

        private OAuthRequest GetRequest(Uri uri, int page, int count, object parameter)
        {
            var combinesParams = parameter;

            if (parameter != null)
            {    

                foreach (var propertery in parameter.GetType().GetTypeInfo().DeclaredProperties)
                {

                }
            }

            return client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, uri)
                   .WithParameters(combinesParams)
                   .Sign(client.AccessToken.Secret);
        }

        protected OAuthRequest PostRequest(Uri uri, string data)
        {
            return client.MakeRequest("POST")
                .WithData(data)
                .ForResource(client.AccessToken.Token, uri)
                .Sign(client.AccessToken.Secret);
        }

        protected T Get<T>(string uri)
        {
            var req = GetRequest(new Uri(uri)).ExecuteRequest().Result;
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

    }
}
