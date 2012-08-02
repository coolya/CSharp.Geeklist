using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Geeklist.Api.Interfaces;
using Chq.OAuth;
using Chq.OAuth.Credentials;
using Windows.Foundation;

namespace CSharp.Geeklist.WinRT.Chq.Connect
{
    public sealed class GeeklistChqServiceProvider
    {
        private readonly Client _client;

        /// <summary>
        /// Creates a new instance of <see cref="GeeklistChqServiceProvider"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
        public GeeklistChqServiceProvider(string consumerKey, string consumerSecret)
        {
            var context = new OAuthContext(consumerKey, consumerSecret,
                                          Geeklist.Connect.GeeklistServiceProvider.RequestTokenUri,
                                           Geeklist.Connect.GeeklistServiceProvider.AuthorizeUri,
                                           Geeklist.Connect.GeeklistServiceProvider.AccessTokenUri);

            _client = new Client(context);


            var requestTokenResponse = _client.MakeRequest("GET")
            .ForRequestToken()
            .Sign()
            .ExecuteRequest().AsTask().Result;

            _client.RequestToken = TokenContainer.Parse(requestTokenResponse);
        }

        /// <summary>
        /// Creates a new instance of <see cref="GeeklistChqServiceProvider"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
        /// <param name="callbackUri">The callback Uri </param>
        public GeeklistChqServiceProvider(string consumerKey, string consumerSecret, string callbackUri)
        {
            var context = new OAuthContext(consumerKey, consumerSecret,
                                           Geeklist.Connect.GeeklistServiceProvider.RequestTokenUri,
                                           Geeklist.Connect.GeeklistServiceProvider.AuthorizeUri,
                                           Geeklist.Connect.GeeklistServiceProvider.AccessTokenUri,
                                           callbackUri, false, SignatureMethods.HMAC_SHA1);

            _client = new Client(context);


            var requestTokenResponse = _client.MakeRequest("GET")
            .ForRequestToken()
            .Sign()
            .ExecuteRequest().AsTask().Result;

            _client.RequestToken = TokenContainer.Parse(requestTokenResponse);
        }

        public Uri GetAuthorizationUri
        {
            get { return _client.GetAuthorizationUri(); }
        }

        ///// <summary>
        ///// Returns an API interface allowing the client application to access protected resources on behalf of a user.
        ///// </summary>
        ///// <param name="accessToken">The API access token.</param>
        ///// <param name="secret">The access token secret.</param>
        ///// <returns>A binding to the service provider's API.</returns>
        public IGeeklist GetApi(string accessToken, string secret)
        {
            _client.AccessToken = new TokenContainer() { Token = accessToken, Secret = secret };

            return new Geeklist.Connect.GeeklistServiceProvider(uri => _client.MakeRequest("GET").ForResource(_client.AccessToken.Token, uri).Sign(_client.AccessToken.Secret).ExecuteRequest(),
                                                    (uri, o) => _client.MakeRequest("GET").ForResource(_client.AccessToken.Token, uri).WithParameters(o).Sign(_client.AccessToken.Secret).ExecuteRequest(),
                                                    uri => _client.MakeRequest("POST").ForResource(_client.AccessToken.Token, uri).Sign(_client.AccessToken.Secret).ExecuteRequest(),
                                                    (uri, o) => _client.MakeRequest("POST").ForResource(_client.AccessToken.Token, uri).WithFormEncodedData(o).Sign(_client.AccessToken.Secret).ExecuteRequest()).GetApi();
        }
    }
}
