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
    public class CardTest
    {
        ICardOperations _ops { get { return _provider.GetApi().CardOperations; } }

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
                                                        (uri, o) => client.MakeRequest("POST") .ForResource(client.AccessToken.Token, uri).WithFormEncodedData(o).Sign(client.AccessToken.Secret).ExecuteRequest().AsAsyncOperation());
        }
        private GeeklistServiceProvider _provider;
        [TestMethod]
        public void GetUserCardsTest()
        {
            var res = _ops.GetUserCards();
        }

        [TestMethod]
        public void GetUserCardsTest2()
        {
            var res = _ops.GetUserCards(1, 2);
        }

        [TestMethod]
        public void GetUserCardsTest3()
        {
            var res = _ops.GetUserCards("coolya");
        }

        [TestMethod]
        public void GetUserCardsTest4()
        {
            var res = _ops.GetUserCards("coolya", 1, 2);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest()
        {
            var res = _ops.GetUserCardsAsync();

            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest2()
        {
            var res = _ops.GetUserCardsAsync(1, 2);
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest3()
        {
            var res = _ops.GetUserCardsAsync("coolya");
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest4()
        {
            var res = _ops.GetUserCardsAsync("coolya", 1, 2);


            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void CreateCardTest()
        {
            var res = _ops.CreateCard("woohooo" + Guid.NewGuid()); // a card from the api " + Guid.NewGuid());
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateCardAsyncTest()
        {
            var res = _ops.CreateCardAsync("woohooo" + Guid.NewGuid());
            Assert.IsNotNull(res.AsTask().Result);
        }
    }
}
