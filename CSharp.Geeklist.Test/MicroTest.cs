using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Geeklist.Api.Interfaces;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace CSharp.Geeklist.Test
{
    [TestClass]
    public class MicroTest
    {

        IMicroOperations _ops;

        [TestInitialize]
        public void Init()
        {
            _ops = new Geeklist.Connect
               .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
               .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").MicroOperations;
        }

        [TestMethod]
        public void CreateMicroTest()
        {
            var res = _ops.CreateMicro("Test" + Guid.NewGuid());

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateMicroTest()
        {
            Assert.Inconclusive();
        }
    }
}

