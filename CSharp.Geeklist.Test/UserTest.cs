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
    public class UserTest
    {
        static IUserOperations _ops = new Geeklist.Connect
               .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
               .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").UserOperations;

        [TestMethod]
        public void GetUserTest()
        {
            var res = _ops.GetUser();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserTest2()
        {
            var res = _ops.GetUser("rekatz");
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void GetUserAsyncTest()
        {
            var res = _ops.GetUserAsync();
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserAsyncTest2()
        {
            var res = _ops.GetUserAsync("rekatz");
            Assert.IsNotNull(res.AsTask().Result);
        }
    }
}
