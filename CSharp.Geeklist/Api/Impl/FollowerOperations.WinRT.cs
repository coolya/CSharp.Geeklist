using System;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class FollowerOperations
    {

        public IAsyncOperation<Models.FollowersResponse> GetUserFollowersAsync()
        {
            return GetUserFollowersAsyncInternal(1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.FollowersResponse> GetUserFollowersAsync(int page, int count)
        {
            return GetUserFollowersAsyncInternal(page, count).AsAsyncOperation();
        }

        public IAsyncOperation<Models.FollowersResponse> GetUserFollowersAsync(string screenName)
        {
            return GetUserFollowersAsyncInternal(screenName, 1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.FollowersResponse> GetUserFollowersAsync(string screenName, int page, int count)
        {
            return GetUserFollowersAsyncInternal(screenName, page, count).AsAsyncOperation();
        }

        public IAsyncAction StartFollowingAsync(string userId)
        {
            return StartFollowingAsyncInternal(userId).AsAsyncAction();
        }

        public IAsyncAction StopFollowingAsync(string userId)
        {
            return StopFollowingAsyncInternal(userId).AsAsyncAction();
        }
    }
}
