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
    public class MicroTest
    {

        IMicroOperations _ops { get { return _provider.GetApi().MicroOperations; } }

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
        public void CreateMicroTest()
        {
            var res = _ops.CreateMicro("Test" + Guid.NewGuid());

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateMicroTest2()
        {
            var rekatzMicro = _ops.CreateMicro("Test" + Guid.NewGuid());
            var res = _ops.CreateMicro("Test" + Guid.NewGuid(), rekatzMicro.Micro.Type, rekatzMicro.Micro.Id);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateMicroAsyncTest()
        {
            var res = _ops.CreateMicroAsync("Test" + Guid.NewGuid());
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void CreateMicroAsyncTest2()
        {
            var rekatzMicro = _ops.CreateMicro("Test" + Guid.NewGuid());
            var res = _ops.CreateMicroAsync("Test" + Guid.NewGuid(), rekatzMicro.Micro.Type, rekatzMicro.Micro.Id);
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserMicrosTest()
        {
            var res = _ops.GetUserMicros();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosTest2()
        {
            var res = _ops.GetUserMicros(1, 11);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosTest3()
        {
            var res = _ops.GetUserMicros("rekatz");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosTest4()
        {
            var res = _ops.GetUserMicros("rekatz", 1 ,11);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest()
        {
            var res = _ops.GetUserMicrosAsync();
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest2()
        {
            var res = _ops.GetUserMicrosAsync(1, 11);
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest3()
        {
            var res = _ops.GetUserMicrosAsync("rekatz");
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest4()
        {
            var res = _ops.GetUserMicrosAsync("rekatz", 1, 11);
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetMicroTest()
        {
            var rekatzMicro = _ops.GetUserMicros("rekatz").MicrosDetails.Micros[0];

            var res = _ops.GetMicro(rekatzMicro.Id);
            Assert.IsNotNull(res);

            //todo compare each field
        }

        [TestMethod]
        public void GetMicroAsyncTest()
        {
            var rekatzMicro = _ops.GetUserMicros("rekatz").MicrosDetails.Micros[0];

            var res = _ops.GetMicroAsync(rekatzMicro.Id);
            Assert.IsNotNull(res.AsTask().Result);

            //todo compare each field
        }

    }
}

