﻿#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using Chq.OAuth;
using Chq.OAuth.Credentials;
using CSharp.Geeklist.Api.Interfaces;
using CSharp.Geeklist.Api.Models;
using Windows.Foundation;


namespace CSharp.Geeklist.Connect
{

    public delegate IAsyncOperation<string> GetHandler(Uri uri);
    public delegate IAsyncOperation<string> GetHandlerWithParameters(Uri uri, object parameters);

    public delegate IAsyncOperation<string> PostHandler(Uri uri);
    public delegate IAsyncOperation<string> PostHandlerWithFormEncodedBody(Uri uri, object body); 

    /// <summary>
	/// Geeklist <see cref="IServiceProvider"/> implementation.
    /// </summary>
    /// <author>Scott Smith</author>
    public sealed class GeeklistServiceProvider
    {
        Client client;

#if SANDBOX
        const string REQUEST_TOKEN_URI = "http://sandbox-api.geekli.st/v1/oauth/request_token";
        const string AUTHORIZE_URI = "http://sandbox.geekli.st/oauth/authorize";
        const string ACCESS_TOKEN_URI = "http://sandbox-api.geekli.st/v1/oauth/access_token";
#else
        const string REQUEST_TOKEN_URI = "http://api.geekli.st/v1/oauth/request_token";
        const string AUTHORIZE_URI = "http://geekli.st/oauth/authorize";
        const string ACCESS_TOKEN_URI = "http://api.geekli.st/v1/oauth/access_token";
#endif
        /// <summary>
		/// Creates a new instance of <see cref="GeeklistServiceProvider"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
		public GeeklistServiceProvider(string consumerKey, string consumerSecret)
        {
            var context = new OAuthContext(consumerKey, consumerSecret,
                                           REQUEST_TOKEN_URI,
                                           AUTHORIZE_URI,
                                           ACCESS_TOKEN_URI);

            client = new Client(context);

            
            var requestTokenResponse = client.MakeRequest("GET")
            .ForRequestToken()
            .Sign()
            .ExecuteRequest().AsTask().Result;

            client.RequestToken = TokenContainer.Parse(requestTokenResponse);
        }

        /// <summary>
        /// Creates a new instance of <see cref="GeeklistServiceProvider"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
        /// <param name="callbackUri">The callback Uri </param>
        public GeeklistServiceProvider(string consumerKey, string consumerSecret, string callbackUri)
        {
            var context = new OAuthContext(consumerKey, consumerSecret,
                                           REQUEST_TOKEN_URI,
                                           AUTHORIZE_URI,
                                           ACCESS_TOKEN_URI,
                                           callbackUri, false, SignatureMethods.HMAC_SHA1);

            client = new Client(context);


            var requestTokenResponse = client.MakeRequest("GET")
            .ForRequestToken()
            .Sign()
            .ExecuteRequest().AsTask().Result;

            client.RequestToken = TokenContainer.Parse(requestTokenResponse);
        }

        public Uri GetAuthorizationUri
        {
            get { return client.GetAuthorizationUri(); }
        }

        public AccessTokenContainer ParseAccessResponse(string data)
        {
            var token = TokenContainer.Parse(data);

            return new AccessTokenContainer(token.Token, token.Secret);
        }


        ///// <summary>
        ///// Returns an API interface allowing the client application to access protected resources on behalf of a user.
        ///// </summary>
        ///// <param name="accessToken">The API access token.</param>
        ///// <param name="secret">The access token secret.</param>
        ///// <returns>A binding to the service provider's API.</returns>
        public IGeeklist GetApi(GetHandler getHandler,
                                GetHandlerWithParameters getHandlerWithParameters,
                                PostHandler postHandler,
                                PostHandlerWithFormEncodedBody postHandlerWithUrlEncodedBody)
        {

            return new Geeklist.Api.Impl.GeeklistApi(uri => getHandler(uri).AsTask(),
                                                     (uri, o) => getHandlerWithParameters(uri, o).AsTask(),
                                                     uri => postHandler(uri).AsTask(),
                                                     (uri, o) => postHandlerWithUrlEncodedBody(uri, o).AsTask());
        }
    }
}
