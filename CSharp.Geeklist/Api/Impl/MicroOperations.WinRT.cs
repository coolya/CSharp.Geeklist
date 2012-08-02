using System;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class MicroOperations
    {      

        public IAsyncOperation<Models.MicrosResponse> GetUserMicrosAsync()
        {
            return GetUserMicrosAsyncInternal(1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.MicrosResponse> GetUserMicrosAsync(int page, int count)
        {
            return GetUserMicrosAsyncInternal(page, count).AsAsyncOperation();
        }

        public IAsyncOperation<Models.MicrosResponse> GetUserMicrosAsync(string screenName)
        {
            return GetUserMicrosAsyncInternal(screenName, 1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.MicrosResponse> GetUserMicrosAsync(string screenName, int page, int count)
        {
            return GetUserMicrosAsyncInternal(screenName, page, count).AsAsyncOperation();
        }

        public IAsyncOperation<Models.MicroResponse> GetMicroAsync(string microId)
        {
            return GetMicroAsyncInternal(microId).AsAsyncOperation();
        }

        public IAsyncOperation<Models.MicroResponse> CreateMicroAsync(string status)
        {
            return CreateMicroAsyncInternal(status).AsAsyncOperation();
        }

        public IAsyncOperation<Models.MicroResponse> CreateMicroAsync(string status, string type, string itemId)
        {
            return CreateMicroAsyncInternal(status, type, itemId).AsAsyncOperation();
        }
    }
}
