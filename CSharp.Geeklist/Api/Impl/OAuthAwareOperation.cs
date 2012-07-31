using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private readonly Func<Uri, Task<string>> _getHandler;
        private readonly Func<Uri, object, Task<string>> _getHandlerWithParameters;
        private readonly Func<Uri, Task<string>> _postHandler;
        private readonly Func<Uri, object, Task<string>> _postHandlerWithUrlEncodedBody;

        public OAuthAwareOperation(Func<Uri, Task<string>> getHandler, Func<Uri, object, Task<string>> getHandlerWithParameters, Func<Uri, Task<string>> postHandler, Func<Uri, object, Task<string>> postHandlerWithUrlEncodedBody)
        {
            _getHandler = getHandler;
            _getHandlerWithParameters = getHandlerWithParameters;
            _postHandler = postHandler;
            _postHandlerWithUrlEncodedBody = postHandlerWithUrlEncodedBody;
        }

        private Task<string> GetRequest(Uri uri)
        {
            return _getHandler(uri);
        }

        private Task<string> GetRequest(Uri uri, int page, int count)
        {
            return GetRequest(uri, new {page = page, count = count});
        }

        private Task<string> GetRequest(Uri uri,  object parameter)
        {
            return _getHandlerWithParameters(uri, parameter);
        }

        private Task<string> PostRequest(Uri uri, object data)
        {
            return _postHandlerWithUrlEncodedBody(uri, data);
        }
        
        private Task<string> PostRequest(Uri uri)
        {
            return _postHandler(uri);
        }

        protected T Get<T>(string uri)
        {
            try
            {
                var req = GetRequest(new Uri(uri)).Result;
                var ret = JsonConvert.DeserializeObject<T>(req);
                

                return ret;
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
                var req = GetRequest(new Uri(uri), parameters).Result;
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
                var req = GetRequest(new Uri(uri), page, count).Result;
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
                var req = await GetRequest(new Uri(uri));
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
                var req = await GetRequest(new Uri(uri), page, count);
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
                var req = await GetRequest(new Uri(uri), parameters);
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
                var req = PostRequest(new Uri(uri)).Result;
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
                var req = PostRequest(new Uri(uri), parameters).Result;
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
                var req = PostRequest(new Uri(uri)).Result;
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
                var req = PostRequest(new Uri(uri), parameters).Result;
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
                var req = await PostRequest(new Uri(uri));
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
                var req = await PostRequest(new Uri(uri), parameters);
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
                var req = await PostRequest(new Uri(uri));
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
                var req = await PostRequest(new Uri(uri), parameters);
            }
            catch (Exception ex)
            {
                var msg = GetMessageFromException(ex);
                throw new GeeklistApiException("Post request failed", msg, ex);
            }
        }

    }
}
