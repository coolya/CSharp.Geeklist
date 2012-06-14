using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    class UserOperations : OAuthAwareOperation, Interfaces.IUserOperations
    {
        const string USERURI =  API_ROOT + "user";
        const string FORINGUSERURI = API_ROOT + "users/:{0}";

        public UserOperations(Client client) : base (client) {}

        public Models.UserResponse GetUser()
        {
            var response = this.GetRequest(new Uri(USERURI), 1, 10).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.UserResponse>(response);            
        }

        public Models.UserResponse GetUser(string screenName)
        {
            var response = this.GetRequest(new Uri(string.Format(FORINGUSERURI, screenName)), 1, 10).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.UserResponse>(response); 
        }

        public async Task<Models.UserResponse> GetUserAsync()
        {
            var response = await this.GetRequest(new Uri(string.Format(USERURI)), 1, 10).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.UserResponse>(response); 
        }

        public async Task<Models.UserResponse> GetUserAsync(string screenName)
        {
            var response = await this.GetRequest(new Uri(string.Format(FORINGUSERURI, screenName)), 1, 10).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.UserResponse>(response); 
        }
    }
}
