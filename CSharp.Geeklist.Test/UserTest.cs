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
    public class UserTest
    {
        IUserOperations _ops { get { return _provider.GetApi().UserOperations; } }

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
        public void GetUserTest()
        {
            var res = _ops.GetUser();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserTest2()
        {
            var res = _ops.GetUser("rekatz");
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void GetUserAsyncTest()
        {
            var res = _ops.GetUserAsync();
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserAsyncTest2()
        {
            var res = _ops.GetUserAsync("rekatz");
            Assert.IsNotNull(res.AsTask().Result);
        }
    }
}
