using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class HighFiveOperations
    {

        public IAsyncAction HighfiveAsync(Enums.HighfiveType type, string itemId)
        {
            return PostAsync(HIGHFIVE, new { type = type.ToString(), gfk = itemId }).AsAsyncAction();
        }
    }
}
