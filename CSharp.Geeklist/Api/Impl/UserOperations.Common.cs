using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    partial class UserOperations : OAuthAwareOperation, Interfaces.IUserOperations
    {
        const string USERURI =  API_ROOT + "user";
        const string FORINGUSERURI = API_ROOT + "users/{0}";

        public UserOperations(Client client) : base (client) {}

        public Models.UserResponse GetUser()
        {
            return Get<Models.UserResponse>(USERURI);            
        }

        public Models.UserResponse GetUser(string screenName)
        {
            return Get<Models.UserResponse>(string.Format(FORINGUSERURI, screenName));
        }
    }
}
