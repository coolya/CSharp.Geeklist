using System;
using CSharp.Geeklist.Api.Enums;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class ActivityOperation 
    {      
        public IAsyncOperation<Models.ActivitiesResponse> GetUserActivitiesAsync(Enums.ActivityType type = ActivityType.All)
        {
            return GetUserActivitiesAsyncInternal(1, 10, type).AsAsyncOperation();
        }

        public IAsyncOperation<Models.ActivitiesResponse> GetUserActivitiesAsync(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return GetUserActivitiesAsyncInternal(page, count, type).AsAsyncOperation();
        }

        public IAsyncOperation<Models.ActivitiesResponse> GetUserActivitiesAsync(string screenName, Enums.ActivityType type = ActivityType.All)
        {
            return GetUserActivitiesAsyncInternal(screenName, 1, 10, type).AsAsyncOperation();
        }

        public IAsyncOperation<Models.ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return GetUserActivitiesAsyncInternal(screenName, page, count, type).AsAsyncOperation();
        }

        public IAsyncOperation<Models.ActivitiesResponse> GetAllActivitiesAsync(Enums.ActivityType type = ActivityType.All)
        {
            return GetAllActivitiesAsyncInternal(1, 10, type).AsAsyncOperation();
        }

        public IAsyncOperation<Models.ActivitiesResponse> GetAllActivitiesAsync(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return GetAllActivitiesAsyncInternal(page, count, type).AsAsyncOperation();
        }
    }
}
