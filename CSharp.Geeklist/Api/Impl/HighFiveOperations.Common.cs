﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;

namespace CSharp.Geeklist.Api.Impl
{
    partial class HighFiveOperations : OAuthAwareOperation, Interfaces.IHighfiveOperations
    {
        const string HIGHFIVE = API_ROOT + "highfive";


        public HighFiveOperations(Func<Uri, Task<string>> getHandler, Func<Uri, object, Task<string>> getHandlerWithParameters, Func<Uri, Task<string>> postHandler, Func<Uri, object, Task<string>> postHandlerWithUrlEncodedBody) : base(getHandler, getHandlerWithParameters, postHandler, postHandlerWithUrlEncodedBody)
        {
        }

        public void Highfive(Enums.HighfiveType type, string itemId)
        {
            Post(HIGHFIVE, new { type = type.ToString(), gfk = itemId });
        }

    }
}
