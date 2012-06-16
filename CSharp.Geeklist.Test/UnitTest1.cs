using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Chq.OAuth;
using Chq.OAuth.Credentials;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Security.Authentication.Web;

namespace CSharp.Geeklist.Test
{
    [TestClass]
    public class UnitTest1
    {
        Mutex mutex = new Mutex();
        [TestMethod]
        public void TestMethod1()
        {
            //var oauth = new OAuthBroker("http://sandbox-api.geekli.st/v1/oauth/access_token",
            //    "http://sandbox.geekli.st/oauth/authorize", 
            //    "http://sandbox-api.geekli.st/v1/oauth/request_token");

            //oauth.Authorize("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts");


            GeneralThreadAffineContext.Run(() =>
            {
                //TestMethod();
            });
            TestMethod().Wait();
 
        }

        private async System.Threading.Tasks.Task TestMethod()
        {
            var context = new OAuthContext("6S8YzYWymDGfb6mB8VPR5Wj_03M",
                "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts",
                "http://sandbox-api.geekli.st/v1/oauth/request_token",
                "http://sandbox.geekli.st/oauth/authorize",
                "http://sandbox-api.geekli.st/v1/oauth/access_token");

            var client = new Client(context);

            // 
            var getreq = client.MakeRequest("GET");
            var requestTokenGetRequest = getreq.ForRequestToken();
            var signedReq = requestTokenGetRequest.Sign();
            var task = signedReq.ExecuteRequest();
            String requestTokenResponse = task.Result;

            client.RequestToken = TokenContainer.Parse(requestTokenResponse);

            Uri authorizationUri = client.GetAuthorizationUri();

            //Authorize the temporary token using the authorizationUri
            //One option is to use the supplied WebAuthenticationBroker
          // WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker
           //     .AuthenticateAsync(WebAuthenticationOptions.None, authorizationUri);

            //string verificationCode = string.Empty;

            //String accessTokenResponse = await client.MakeRequest("GET")
            //        .ForAccessToken(client.RequestToken.Token, verificationCode)
            //        .Sign(client.RequestToken.Secret)
            //        .ExecuteRequest();

            //client.AccessToken = TokenContainer.Parse(accessTokenResponse);


            client.AccessToken = new TokenContainer() { Token = "mXTwZHawIxlOTf-rP9WpplrFERE", Secret = "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA" };

            String getResponse = await client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, new Uri("http://sandbox-api.geekli.st/v1/user/cards"))
                   .Sign(client.AccessToken.Secret)
                   .ExecuteRequest();


            var code = getResponse.ToString();

            mutex.ReleaseMutex();
        }
    }
}
