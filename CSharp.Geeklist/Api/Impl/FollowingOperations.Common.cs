using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    partial class FollowingOperations : OAuthAwareOperation, Interfaces.IFollowingOperations
    {
        const string OWN_FOLLOWINGS = API_ROOT + "user/following";
        const string FORING_FOLLOWINGS = API_ROOT + "users/{0}/following";

        public FollowingOperations(Client client): base(client) {}

        public Models.FollowingResponse GetUserFollowing()
        {
            return GetUserFollowing(1, 10);
        }

        public Models.FollowingResponse GetUserFollowing(int page, int count)
        {
            return Get<Models.FollowingResponse>(OWN_FOLLOWINGS, page, count);
        }

        public Models.FollowingResponse GetUserFollowing(string screenName)
        {
            return GetUserFollowing(screenName, 1, 10);
        }

        public Models.FollowingResponse GetUserFollowing(string screenName, int page, int count)
        {
            return Get<Models.FollowingResponse>(string.Format(FORING_FOLLOWINGS, screenName), page, count);
        }

        private Task<Models.FollowingResponse> GetUserFollowingAsyncInternal(int page, int count)
        {
            return GetAsync<Models.FollowingResponse>(OWN_FOLLOWINGS, page, count);
        }

        private Task<Models.FollowingResponse> GetUserFollowingAsyncInternal(string screenName, int page, int count)
        {
            return GetAsync<Models.FollowingResponse>(string.Format(FORING_FOLLOWINGS, screenName), page, count);
        }
    }
}
