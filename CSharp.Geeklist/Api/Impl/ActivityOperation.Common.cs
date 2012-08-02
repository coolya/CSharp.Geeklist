using System;
using System.Threading.Tasks;
using CSharp.Geeklist.Api.Enums;

namespace CSharp.Geeklist.Api.Impl
{
    partial class ActivityOperation : OAuthAwareOperation, Interfaces.IActivityOperations
    {
        const string OWN_ACTIVITIES = API_ROOT + "user/activity";
        const string FORING_ACTIVITIES = API_ROOT + "users/{0}/activity";
        const string GLOBAL_ACTIVITIES = API_ROOT + "activity";


        public ActivityOperation(Func<Uri, Task<string>> getHandler, Func<Uri, object, Task<string>> getHandlerWithParameters, Func<Uri, Task<string>> postHandler, Func<Uri, object, Task<string>> postHandlerWithUrlEncodedBody) : base(getHandler, getHandlerWithParameters, postHandler, postHandlerWithUrlEncodedBody)
        {
        }

        public Models.ActivitiesResponse GetUserActivities(Enums.ActivityType type = ActivityType.All)
        {
            return GetUserActivities(1, 10, type);
        }

        public Models.ActivitiesResponse GetUserActivities(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return Get<Models.ActivitiesResponse>(OWN_ACTIVITIES, new { page = page, count = count, type = type.ToString() });
        }

        public Models.ActivitiesResponse GetUserActivities(string screenName, Enums.ActivityType type = ActivityType.All)
        {
            return GetUserActivities(screenName, 1, 10, type);
        }

        public Models.ActivitiesResponse GetUserActivities(string screenName, int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return Get<Models.ActivitiesResponse>(string.Format(FORING_ACTIVITIES, screenName), new { page = page, count = count, type = type.ToString() });
        }

        public Models.ActivitiesResponse GetAllActivities(Enums.ActivityType type = ActivityType.All)
        {
            return GetAllActivities(1, 10, type);
        }

        public Models.ActivitiesResponse GetAllActivities(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return Get<Models.ActivitiesResponse>(GLOBAL_ACTIVITIES, new { page = page, count = count, type = type.ToString() });
        }

        private Task<Models.ActivitiesResponse> GetUserActivitiesAsyncInternal(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return GetAsync<Models.ActivitiesResponse>(OWN_ACTIVITIES, new { page = page, count = count, type = type.ToString() });
        }

        private Task<Models.ActivitiesResponse> GetUserActivitiesAsyncInternal(string screenName, int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return GetAsync<Models.ActivitiesResponse>(string.Format(FORING_ACTIVITIES, screenName), new { page = page, count = count, type = type.ToString() });
        }

        private Task<Models.ActivitiesResponse> GetAllActivitiesAsyncInternal(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return GetAsync<Models.ActivitiesResponse>(GLOBAL_ACTIVITIES, new { page = page, count = count, type = type.ToString() });
        }
    }
}
