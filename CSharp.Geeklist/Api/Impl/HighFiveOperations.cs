using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;

namespace CSharp.Geeklist.Api.Impl
{
    class HighFiveOperations : OAuthAwareOperation, Interfaces.IHighfiveOperations
    {
        public HighFiveOperations(Client client) : base(client)
        {

        }
        public bool Highfive(Enums.HighfiveType type, string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HighfiveAsync(Enums.HighfiveType type, string itemId)
        {
            throw new NotImplementedException();
        }
    }
}
