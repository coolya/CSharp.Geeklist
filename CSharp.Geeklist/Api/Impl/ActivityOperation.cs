using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;
using CSharp.Geeklist.Api.Enums;

namespace CSharp.Geeklist.Api.Impl
{
    class ActivityOperation : OAuthAwareOperation, Interfaces.IActivityOperations
    {
        const string OWN_ACTIVITIES = API_ROOT + "user/activity";
        const string FORING_ACTIVITIES = API_ROOT + "users/{0}/activity";
        const string GLOBAL_ACTIVITIES = API_ROOT + "activity";

        public ActivityOperation(Client client) : base(client) {}

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

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(Enums.ActivityType type = ActivityType.All)
        {
            return await GetUserActivitiesAsync(1, 10, type);
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return await GetAsync<Models.ActivitiesResponse>(OWN_ACTIVITIES, new { page = page, count = count, type = type.ToString() });
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(string screenName, Enums.ActivityType type = ActivityType.All)
        {
            return await GetUserActivitiesAsync(screenName, 1, 10, type);
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return await GetAsync<Models.ActivitiesResponse>(string.Format(FORING_ACTIVITIES, screenName), new { page = page, count = count, type = type.ToString() });
        }

        public async Task<Models.ActivitiesResponse> GetAllActivitiesAsync(Enums.ActivityType type = ActivityType.All)
        {
            return await GetAllActivitiesAsync(1, 10, type);
        }

        public async Task<Models.ActivitiesResponse> GetAllActivitiesAsync(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            return await GetAsync<Models.ActivitiesResponse>(GLOBAL_ACTIVITIES, new { page = page, count = count, type = type.ToString() });
        }
    }
}
