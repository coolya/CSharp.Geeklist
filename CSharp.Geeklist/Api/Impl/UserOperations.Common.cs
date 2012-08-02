using System;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Impl
{
    partial class UserOperations : OAuthAwareOperation, Interfaces.IUserOperations
    {
        const string USERURI =  API_ROOT + "user";
        const string FORINGUSERURI = API_ROOT + "users/{0}";


        public UserOperations(Func<Uri, Task<string>> getHandler, Func<Uri, object, Task<string>> getHandlerWithParameters, Func<Uri, Task<string>> postHandler, Func<Uri, object, Task<string>> postHandlerWithUrlEncodedBody) : base(getHandler, getHandlerWithParameters, postHandler, postHandlerWithUrlEncodedBody)
        {
        }

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
