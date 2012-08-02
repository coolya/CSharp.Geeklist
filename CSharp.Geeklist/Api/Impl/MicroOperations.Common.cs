using System;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
    partial class MicroOperations : OAuthAwareOperation, Interfaces.IMicroOperations
    {

        const string OWN_MICROS = API_ROOT + "user/micros";
        const string FORING_MICROWS = API_ROOT + "users/{0}/micros";
        const string SINGLE_MICRO = API_ROOT + "micros/{0}";
        const string CREATE_MICRO = API_ROOT + "micros";

        public MicroOperations(Func<Uri, Task<string>> getHandler, Func<Uri, object, Task<string>> getHandlerWithParameters, Func<Uri, Task<string>> postHandler, Func<Uri, object, Task<string>> postHandlerWithUrlEncodedBody) : base(getHandler, getHandlerWithParameters, postHandler, postHandlerWithUrlEncodedBody)
        {
        }

        public Models.MicrosResponse GetUserMicros()
        {
            return GetUserMicros(10, 1);
        }

        public Models.MicrosResponse GetUserMicros(int page, int count)
        {
           return  Get<Models.MicrosResponse>(OWN_MICROS, page, count);
        }

        public Models.MicrosResponse GetUserMicros(string screenName)
        {
            return GetUserMicros(screenName, 1, 10);
        }

        public Models.MicrosResponse GetUserMicros(string screenName, int page, int count)
        {
            return Get<Models.MicrosResponse>(string.Format(FORING_MICROWS, screenName), page, count);
        }

        public Models.MicroResponse GetMicro(string microId)
        {
            return Get<Models.MicroResponse>(string.Format(SINGLE_MICRO, microId));
        }

        public Models.MicroResponse CreateMicro(string status)
        {
            return Post<Models.MicroResponse>(CREATE_MICRO, new { status = status });
        }

        public Models.MicroResponse CreateMicro(string status, string type, string itemId)
        {
            return Post<Models.MicroResponse>(CREATE_MICRO, new { status = status, type = type, in_reply_to = itemId });
        }

        private Task<Models.MicrosResponse> GetUserMicrosAsyncInternal(int page, int count)
        {
            return GetAsync<Models.MicrosResponse>(OWN_MICROS, page, count);
        }

        private Task<Models.MicrosResponse> GetUserMicrosAsyncInternal(string screenName, int page, int count)
        {
            return GetAsync<Models.MicrosResponse>(string.Format(FORING_MICROWS, screenName), page, count);
        }

        private Task<Models.MicroResponse> GetMicroAsyncInternal(string microId)
        {
            return GetAsync<Models.MicroResponse>(string.Format(SINGLE_MICRO, microId));
        }

        private Task<Models.MicroResponse> CreateMicroAsyncInternal(string status)
        {
            return PostAsync<Models.MicroResponse>(CREATE_MICRO, new { status = status });
        }

        private Task<Models.MicroResponse> CreateMicroAsyncInternal(string status, string type, string itemId)
        {
            return PostAsync<Models.MicroResponse>(CREATE_MICRO, new { status = status, type = type, in_reply_to = itemId });
        }
    }
}
