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
    public class FollowingTest
    {
        IFollowingOperations _ops;

        [TestInitialize]
        public void Init()
        {
            _ops = new Geeklist.Connect
               .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
               .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").FollowingOperations;
        }

        [TestMethod]
        public void GetUserFollowingTest()
        {
            var res = _ops.GetUserFollowing();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowingTest2()
        {
            var res = _ops.GetUserFollowing("rekatz");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowingTest3()
        {
            var res = _ops.GetUserFollowing("rekatz", 1, 11);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowingTest4()
        {
            var res = _ops.GetUserFollowing(1, 11);
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void GetUserFollowingAsyncTest()
        {
            var res = _ops.GetUserFollowingAsync();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserFollowingAsyncTest2()
        {
            var res = _ops.GetUserFollowingAsync("rekatz");
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserFollowingAsyncTest3()
        {
            var res = _ops.GetUserFollowingAsync("rekatz", 1, 11);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserFollowingAsyncTest4()
        {
            var res = _ops.GetUserFollowingAsync(1, 11);
            Assert.IsNotNull(res.Result);
        }
    }
}
