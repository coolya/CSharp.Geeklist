using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    class FollowerOperations : OAuthAwareOperation, Interfaces.IFollowerOperations
    {

        const string OWN_FOLLOWERS = API_ROOT + "user/followers";
        const string FORING_FOLLOWERS = API_ROOT + "users/:{0}/followers";

        public FollowerOperations(Client client) : base(client) {}

        public Models.FollowersResponse GetUserFollowers()
        {
            return GetUserFollowers(1, 10);
        }

        public Models.FollowersResponse GetUserFollowers(int page, int count)
        {
            return Get<Models.FollowersResponse>(OWN_FOLLOWERS, page, count);
        }

        public Models.FollowersResponse GetUserFollowers(string screenName)
        {
            return GetUserFollowers(screenName, 1, 10);
        }

        public Models.FollowersResponse GetUserFollowers(string screenName, int page, int count)
        {
            return Get<Models.FollowersResponse>(string.Format(FORING_FOLLOWERS, screenName), page, count);
        }

        public bool StartFollowing(string userId)
        {
            throw new NotImplementedException();
        }

        public bool StopFollowing(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.FollowersResponse> GetUserFollowersAsync()
        {
            return await GetUserFollowersAsync(1, 10);
        }

        public async Task<Models.FollowersResponse> GetUserFollowersAsync(int page, int count)
        {
            return await GetAsync<Models.FollowersResponse>(OWN_FOLLOWERS, page, count);
        }

        public async Task<Models.FollowersResponse> GetUserFollowersAsync(string screenName)
        {
            return await GetUserFollowersAsync(screenName, 1, 10);
        }

        public async Task<Models.FollowersResponse> GetUserFollowersAsync(string screenName, int page, int count)
        {
            return await GetAsync<Models.FollowersResponse>(string.Format(FORING_FOLLOWERS, screenName), page, count);
        }

        public async Task<bool> StartFollowingAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StopFollowingAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
