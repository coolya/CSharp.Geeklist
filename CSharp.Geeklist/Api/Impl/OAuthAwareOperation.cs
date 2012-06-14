using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using System.Reflection;
using System.Reflection.Emit;

namespace CSharp.Geeklist.Api.Impl
{
    class OAuthAwareOperation
    {
        protected const string API_ROOT = "http://sandbox-api.geekli.st/v1/";
        Client client;

        public OAuthAwareOperation(Client client)
        {
            this.client = client;
        }

        protected OAuthRequest GetRequest(Uri uri)
        {
            return client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, uri)
                    .Sign(client.AccessToken.Secret);
        }

        protected OAuthRequest GetRequest(Uri uri, int page, int count)
        {
            return client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, uri)
                   .WithParameters(new { page = page, count = count})
                   .Sign(client.AccessToken.Secret);
        }

        protected OAuthRequest GetRequest(Uri uri, int page, int count, object parameter)
        {
            var combinesParams = parameter;

            if (parameter != null)
            {    

                foreach (var propertery in parameter.GetType().GetTypeInfo().DeclaredProperties)
                {

                }
            }

            return client.MakeRequest("GET")
                   .ForResource(client.AccessToken.Token, uri)
                   .WithParameters(combinesParams)
                   .Sign(client.AccessToken.Secret);
        }

        protected OAuthRequest PostRequest(Uri uri, string data)
        {
            return client.MakeRequest("POST")
                .WithData(data)
                .ForResource(client.AccessToken.Token, uri)
                .Sign(client.AccessToken.Secret);
        }

    }
}
