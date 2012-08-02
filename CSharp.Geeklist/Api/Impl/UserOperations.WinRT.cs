using System;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class UserOperations 
    {
      
        public IAsyncOperation<Models.UserResponse> GetUserAsync()
        {
            return GetAsync<Models.UserResponse>(USERURI).AsAsyncOperation();
        }

        public IAsyncOperation<Models.UserResponse> GetUserAsync(string screenName)
        {
            return GetAsync<Models.UserResponse>(string.Format(FORINGUSERURI, screenName)).AsAsyncOperation();
        }
    }
}
