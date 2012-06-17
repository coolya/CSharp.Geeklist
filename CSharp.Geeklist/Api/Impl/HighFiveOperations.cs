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
        const string HIGHFIVE = API_ROOT + "highfive";

        public HighFiveOperations(Client client) : base(client) {}

        public void Highfive(Enums.HighfiveType type, string itemId)
        {
            Post(HIGHFIVE, new { type = type.ToString(), gfk = itemId });
        }

        public async Task HighfiveAsync(Enums.HighfiveType type, string itemId)
        {
            await PostAsync(HIGHFIVE, new { type = type.ToString(), gfk = itemId });
        }
    }
}
