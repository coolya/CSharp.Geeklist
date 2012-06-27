using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class FollowingOperations
    {
        public IAsyncOperation<Models.FollowingResponse> GetUserFollowingAsync()
        {
            return GetUserFollowingAsyncInternal(1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.FollowingResponse> GetUserFollowingAsync(int page, int count)
        {
            return GetUserFollowingAsyncInternal(page, count).AsAsyncOperation();
        }

        public IAsyncOperation<Models.FollowingResponse> GetUserFollowingAsync(string screenName)
        {
            return GetUserFollowingAsyncInternal(screenName, 1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.FollowingResponse> GetUserFollowingAsync(string screenName, int page, int count)
        {
            return GetUserFollowingAsyncInternal(screenName, page, count).AsAsyncOperation();
        }
    }
}
