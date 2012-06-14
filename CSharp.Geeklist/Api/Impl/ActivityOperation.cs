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
        const string FORING_ACTIVITIES = API_ROOT + "users/:{0}/activity";
        const string GLOBAL_ACTIVITIES = API_ROOT + "activity";

        public ActivityOperation(Client client) : base(client)
        {

        }
        public Models.ActivitiesResponse GetUserActivities(Enums.ActivityType type = ActivityType.All)
        {
            var req = GetRequest(new Uri(OWN_ACTIVITIES), 1, 10).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.ActivitiesResponse>(req);
        }

        public Models.ActivitiesResponse GetUserActivities(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            var req = GetRequest(new Uri(OWN_ACTIVITIES), page, count).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.ActivitiesResponse>(req);
        }

        public Models.ActivitiesResponse GetUserActivities(string screenName, Enums.ActivityType type = ActivityType.All)
        {
            var req = GetRequest(new Uri(string.Format(FORING_ACTIVITIES, screenName)), 1, 10).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.ActivitiesResponse>(req);
        }

        public Models.ActivitiesResponse GetUserActivities(string screenName, int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            var req = GetRequest(new Uri(string.Format(FORING_ACTIVITIES, screenName)), page, count).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.ActivitiesResponse>(req);
        }

        public Models.ActivitiesResponse GetAllActivities(Enums.ActivityType type = ActivityType.All)
        {
            var req = GetRequest(new Uri(GLOBAL_ACTIVITIES), 1, 10).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.ActivitiesResponse>(req);
        }

        public Models.ActivitiesResponse GetAllActivities(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            var req = GetRequest(new Uri(GLOBAL_ACTIVITIES), page, count).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.ActivitiesResponse>(req);
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(Enums.ActivityType type = ActivityType.All)
        {
            var req = await  GetRequest(new Uri(OWN_ACTIVITIES), 1, 10).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.ActivitiesResponse>(req);
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            var req = await GetRequest(new Uri(OWN_ACTIVITIES), page, count).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.ActivitiesResponse>(req);
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(string screenName, Enums.ActivityType type = ActivityType.All)
        {
            var req = await GetRequest(new Uri(string.Format(FORING_ACTIVITIES, screenName)), 1, 10).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.ActivitiesResponse>(req);
        }

        public async Task<Models.ActivitiesResponse> GetUserActivitiesAsync(string screenName, int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            var req = await GetRequest(new Uri(string.Format(FORING_ACTIVITIES, screenName)), page, count).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.ActivitiesResponse>(req);
        }

        public async Task<Models.ActivitiesResponse> GetAllActivitiesAsync(Enums.ActivityType type = ActivityType.All)
        {
            var req = await GetRequest(new Uri(GLOBAL_ACTIVITIES), 1, 10).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.ActivitiesResponse>(req);
        }

        public async Task<Models.ActivitiesResponse> GetAllActivitiesAsync(int page, int count, Enums.ActivityType type = ActivityType.All)
        {
            var req = await GetRequest(new Uri(GLOBAL_ACTIVITIES), page, count).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.ActivitiesResponse>(req);
        }
    }
}
