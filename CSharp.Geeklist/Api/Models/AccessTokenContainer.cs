using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Geeklist.Api.Models
{
    public sealed class AccessTokenContainer
    {
        public AccessTokenContainer(string token, string secret)
        {
            this.Token = token;
            this.Secret = secret;
        }
        public string Token { get; private set; }
        public string Secret { get; private set; }
    }
}
