using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Connect;
using Chq.OAuth;
using Chq.OAuth.Credentials;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace CSharp.Geeklist.Test
{
    [TestClass]
    public class FollowingTest
    {
        IFollowingOperations _ops { get { return _provider.GetApi().FollowingOperations; } }

        [TestInitialize]
        public void Init()
        {
            var context = new OAuthContext("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts",
                                          GeeklistServiceProvider.RequestTokenUri,
                                          GeeklistServiceProvider.AuthorizeUri,
                                          GeeklistServiceProvider.AccessTokenUri);

            var client = new Client(context);

            var requestTokenResponse = client.MakeRequest("GET")
            .ForRequestToken()
            .Sign()
            .ExecuteRequest().Result;

            client.RequestToken = TokenContainer.Parse(requestTokenResponse);

            client.AccessToken = new TokenContainer() { Token = "mXTwZHawIxlOTf-rP9WpplrFERE", Secret = "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA" };

            _provider = new GeeklistServiceProvider(uri => client.MakeRequest("GET").ForResource(client.AccessToken.Token, uri).Sign(client.AccessToken.Secret).ExecuteRequest().AsAsyncOperation(),
                                                    (uri, o) => client.MakeRequest("GET").ForResource(client.AccessToken.Token, uri).WithParameters(o).Sign(client.AccessToken.Secret).ExecuteRequest().AsAsyncOperation(),
                                                    uri => client.MakeRequest("POST").ForResource(client.AccessToken.Token, uri).Sign(client.AccessToken.Secret).ExecuteRequest().AsAsyncOperation(),
                                                    (uri, o) => client.MakeRequest("POST").ForResource(client.AccessToken.Token, uri).WithFormEncodedData(o).Sign(client.AccessToken.Secret).ExecuteRequest().AsAsyncOperation());
        }
        private GeeklistServiceProvider _provider;

        [TestMethod]
        public void GetUserFollowingTest()
        {
            var res = _ops.GetUserFollowing();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowingTest2()
        {
            var res = _ops.GetUserFollowing("rekatz");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowingTest3()
        {
            var res = _ops.GetUserFollowing("rekatz", 1, 11);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowingTest4()
        {
            var res = _ops.GetUserFollowing(1, 11);
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void GetUserFollowingAsyncTest()
        {
            var res = _ops.GetUserFollowingAsync();
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserFollowingAsyncTest2()
        {
            var res = _ops.GetUserFollowingAsync("rekatz");
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserFollowingAsyncTest3()
        {
            var res = _ops.GetUserFollowingAsync("rekatz", 1, 11);
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserFollowingAsyncTest4()
        {
            var res = _ops.GetUserFollowingAsync(1, 11);
            Assert.IsNotNull(res.AsTask().Result);
        }
    }
}
