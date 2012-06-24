using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using System.Reflection;
using System.Reflection.Emit;
using Newtonsoft.Json;
using System.Net;

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

        private OAuthRequest PostRequest(Uri uri, object data)
        {
            return client.MakeRequest("POST")
                .ForResource(client.AccessToken.Token, uri)
                .WithFormEncodedData(data)                 
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
            try
            {
                var req = GetRequest(new Uri(uri)).ExecuteRequest().Result;
                return JsonConvert.DeserializeObject<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Get request failed", msg, ex);
            }

        }

        protected T Get<T>(string uri, object parameters)
        {
            try
            {
                var req = GetRequest(new Uri(uri), parameters).ExecuteRequest().Result;
                return JsonConvert.DeserializeObject<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Get request failed", msg, ex);
            }
        }

        protected T Get<T>(string uri, int page, int count)
        {
            try
            {
                var req = GetRequest(new Uri(uri), page, count).ExecuteRequest().Result;
                return JsonConvert.DeserializeObject<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Get request failed", msg, ex);
            }
        }

        protected async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                var req = await GetRequest(new Uri(uri)).ExecuteRequest();
                return await JsonConvert.DeserializeObjectAsync<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Get request failed", msg, ex);
            }
        }

        protected async Task<T> GetAsync<T>(string uri, int page, int count)
        {
            try
            {
                var req = await GetRequest(new Uri(uri), page, count).ExecuteRequest();
                return await JsonConvert.DeserializeObjectAsync<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Get request failed", msg, ex);
            }
        }

        protected async Task<T> GetAsync<T>(string uri, object parameters)
        {
            try
            {
                var req = await GetRequest(new Uri(uri), parameters).ExecuteRequest();
                return await JsonConvert.DeserializeObjectAsync<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Get request failed", msg,  ex);
            }
        }

        protected T Post<T>(string uri)
        {
            try
            {
                var req = PostRequest(new Uri(uri)).ExecuteRequest().Result;
                return JsonConvert.DeserializeObject<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

        protected T Post<T>(string uri, object parameters)
        {
            try
            {
                var req = PostRequest(new Uri(uri), parameters).ExecuteRequest().Result;
                return JsonConvert.DeserializeObject<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);     
            }
        }

        private string GetMessageFromException(Exception ex)
        {
            var webex = ex.InnerException as WebException;

            if (webex != null)
            {
                var resposne = webex.Response;

                if (resposne.ContentLength > 0)
                {
                    var stream = resposne.GetResponseStream();

                    byte[] data = new byte[resposne.ContentLength];
                    stream.Read(data, 0, (int)resposne.ContentLength);

                    return Encoding.UTF8.GetString(data, 0, data.Length);
                }
            }

            return string.Empty;
        }

        protected void Post(string uri)
        {   //result is irgnores, the request will throw an exception in cause of it fails
            try
            {
                var req = PostRequest(new Uri(uri)).ExecuteRequest().Result;
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

        protected void Post(string uri, object parameters)
        {   //result is irgnores, the request will throw an exception in cause of it fails
            try
            {
                var req = PostRequest(new Uri(uri), parameters).ExecuteRequest().Result;
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

        protected async Task<T> PostAsync<T>(string uri)
        {
            try
            {
                var req = await PostRequest(new Uri(uri)).ExecuteRequest();
                return await JsonConvert.DeserializeObjectAsync<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

        protected async Task<T> PostAsync<T>(string uri, object parameters)
        {
            try
            {
                var req = await PostRequest(new Uri(uri), parameters).ExecuteRequest();
                return await JsonConvert.DeserializeObjectAsync<T>(req);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

        protected async Task PostAsync(string uri)
        {
            try
            {
                var req = await PostRequest(new Uri(uri)).ExecuteRequest();
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

        protected async Task PostAsync(string uri, object parameters)
        {
            try
            {
                var req = await PostRequest(new Uri(uri), parameters).ExecuteRequest();
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

    }
}
