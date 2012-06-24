using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;

namespace CSharp.Geeklist.Api.Impl
{
    class MicroOperations : OAuthAwareOperation, Interfaces.IMicroOperations
    {

        const string OWN_MICROS = API_ROOT + "user/micros";
        const string FORING_MICROWS = API_ROOT + "users/{0}/micros";
        const string SINGLE_MICRO = API_ROOT + "micros/{0}";
        const string CREATE_MICRO = API_ROOT + "micros";

        public MicroOperations(Client client) : base(client) {}

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

        public async Task<Models.MicrosResponse> GetUserMicrosAsync()
        {
            return await GetUserMicrosAsync(1, 10);
        }

        public async Task<Models.MicrosResponse> GetUserMicrosAsync(int page, int count)
        {
            return await GetAsync<Models.MicrosResponse>(OWN_MICROS, page, count);
        }

        public async Task<Models.MicrosResponse> GetUserMicrosAsync(string screenName)
        {
            return await GetUserMicrosAsync(screenName, 1, 10);
        }

        public async Task<Models.MicrosResponse> GetUserMicrosAsync(string screenName, int page, int count)
        {
            return await GetAsync<Models.MicrosResponse>(string.Format(FORING_MICROWS, screenName), page, count);
        }

        public async Task<Models.MicroResponse> GetMicroAsync(string microId)
        {
            return await GetAsync<Models.MicroResponse>(string.Format(SINGLE_MICRO, microId));
        }

        public async Task<Models.MicroResponse> CreateMicroAsync(string status)
        {
            return await PostAsync<Models.MicroResponse>(CREATE_MICRO, new { status = status });
        }

        public async Task<Models.MicroResponse> CreateMicroAsync(string status, string type, string itemId)
        {
            return await PostAsync<Models.MicroResponse>(CREATE_MICRO, new { status = status, type = type, in_reply_to = itemId });
        }
    }
}
