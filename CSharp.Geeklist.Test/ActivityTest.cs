using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Geeklist.Connect;
using Chq.OAuth;
using Chq.OAuth.Credentials;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace CSharp.Geeklist.Test
{
    [TestClass]
    public class ActivityTest
    {
        CSharp.Geeklist.Api.Interfaces.IActivityOperations _ops { get { return _provider.GetApi().ActivityOperations; } }


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
        public void GetAllActivitiesTest()
        {
            var res = _ops.GetAllActivities();
            Assert.AreEqual(10, res.Activities.Count);
        }

        [TestMethod]
        public void GetAllActivitiesTest2()
        {
            var res = _ops.GetAllActivities(1, 20);
            Assert.AreEqual(20, res.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesTest()
        {
            var res = _ops.GetUserActivities();
            Assert.AreEqual(10, res.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesTest2()
        {
            var res = _ops.GetUserActivities(1, 11);
            Assert.AreEqual(11, res.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesTest3()
        {
            var res = _ops.GetUserActivities("coolya");
                  }

        [TestMethod]
        public void GetUserActivitiesTest4()
        {
            var res = _ops.GetUserActivities("coolya",1, 11);
        }

        [TestMethod]
        public void GetAllActivitiesAsyncTest()
        {
            var res = _ops.GetAllActivitiesAsync();


            
            Assert.AreEqual(10, res.AsTask().Result.Activities.Count);
        }

        [TestMethod]
        public void GetAllActivitiesAsyncTest2()
        {
            var res = _ops.GetAllActivitiesAsync(1, 11);
            Assert.AreEqual(11, res.AsTask().Result.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest()
        {
            var res = _ops.GetUserActivitiesAsync();
            Assert.AreEqual(10, res.AsTask().Result.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest2()
        {
            var res = _ops.GetUserActivitiesAsync(1, 11);
            Assert.AreEqual(11, res.AsTask().Result.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest3()
        {
            var res = _ops.GetUserActivitiesAsync("coolya");
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest4()
        {
            var res = _ops.GetUserActivitiesAsync("coolya", 1, 11);
        }
    }
}
