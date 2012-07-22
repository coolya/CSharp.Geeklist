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
    public class FollowerTest
    {
        static CSharp.Geeklist.Api.Interfaces.IFollowerOperations _ops = new Geeklist.Connect
                .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
                .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").FollowerOperations;

        private IUserOperations UserOps
        {
            get
            {
                return new Geeklist.Connect
                    .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
                    .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").UserOperations;
            }
        }

        [TestMethod]
        public void GetUserFollowersTest()
        {
            var res = _ops.GetUserFollowers();

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowersTest2()
        {
            var res = _ops.GetUserFollowers("coolya");

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowersTest3()
        {
            var res = _ops.GetUserFollowers(1, 11);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowersTest4()
        {
            var res = _ops.GetUserFollowers("coolya", 1 ,11);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserFollowersAsyncTest()
        {
            var res = _ops.GetUserFollowersAsync();

            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserFollowersAsyncTest2()
        {
            var res = _ops.GetUserFollowersAsync("coolya");

            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserFollowersAsyncTest3()
        {
            var res = _ops.GetUserFollowersAsync(1, 11);

            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserFollowersAsyncTest4()
        {
            var res = _ops.GetUserFollowersAsync("coolya", 1, 11);

            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void StartFollowingTest()
        {
            var user = UserOps.GetUser("rekatz");

            _ops.StartFollowing(user.User.Id);
        }


        [TestMethod]
        public void StopFollowingTest()
        {
            var user = UserOps.GetUser("rekatz");

            _ops.StopFollowing(user.User.Id);
        }

        [TestMethod]
        public void StartFollowingAsyncTest()
        {
            var user = UserOps.GetUser("rekatz");

            GeneralThreadAffineContext.Run(() => _ops.StartFollowingAsync(user.User.Id));
        }


        [TestMethod]
        public void StopFollowingAsyncTest()
        {
            var user = UserOps.GetUser("rekatz");
            GeneralThreadAffineContext.Run(() =>  _ops.StopFollowingAsync(user.User.Id));
        }

    }
}
