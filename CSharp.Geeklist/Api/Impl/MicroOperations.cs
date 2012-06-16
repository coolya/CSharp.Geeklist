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
        const string SINGLE_MICRO = API_ROOT + "micros/:{0}";

        public MicroOperations(Client client) : base(client) {}

        public Models.MicrosResponse GetUserMicros()
        {
            throw new NotImplementedException();
        }

        public Models.MicrosResponse GetUserMicros(int page, int count)
        {
            throw new NotImplementedException();
        }

        public Models.MicrosResponse GetUserMicros(string screenName)
        {
            throw new NotImplementedException();
        }

        public Models.MicrosResponse GetUserMicros(string screenName, int page, int count)
        {
            throw new NotImplementedException();
        }

        public Models.MicroResponse GetMicro(string microId)
        {
            throw new NotImplementedException();
        }

        public Models.MicroResponse CreateMicro(string status)
        {
            throw new NotImplementedException();
        }

        public Models.MicroResponse CreateMicro(string status, string type, string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicrosResponse> GetUserMicrosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicrosResponse> GetUserMicrosAsync(int page, int count)
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicrosResponse> GetUserMicrosAsync(string screenName)
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicrosResponse> GetUserMicrosAsync(string screenName, int page, int count)
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicroResponse> GetMicroAsync(string microId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicroResponse> CreateMicroAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<Models.MicroResponse> CreateMicroAsync(string status, string type, string itemId)
        {
            throw new NotImplementedException();
        }
    }
}
