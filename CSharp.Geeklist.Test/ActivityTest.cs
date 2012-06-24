using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace CSharp.Geeklist.Test
{
    [TestClass]
    public class ActivityTest
    {
        CSharp.Geeklist.Api.Interfaces.IActivityOperations _ops;

        [TestInitialize]
        public void Init()
        {
            _ops = new Geeklist.Connect
                .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
                .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").ActivityOperations;
        }

        [TestMethod]
        public void GetAllActivitiesTest()
        {
            var res = _ops.GetAllActivities();
            Assert.AreEqual(10, res.Activities.Count);
        }

        [TestMethod]
        public void GetAllActivitiesTest2()
        {
            var res = _ops.GetAllActivities(1, 20);
            Assert.AreEqual(20, res.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesTest()
        {
            var res = _ops.GetUserActivities();
            Assert.AreEqual(10, res.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesTest2()
        {
            var res = _ops.GetUserActivities(1, 11);
            Assert.AreEqual(11, res.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesTest3()
        {
            var res = _ops.GetUserActivities("coolya");
                  }

        [TestMethod]
        public void GetUserActivitiesTest4()
        {
            var res = _ops.GetUserActivities("coolya",1, 11);
        }

        [TestMethod]
        public void GetAllActivitiesAsyncTest()
        {
            var res = _ops.GetAllActivitiesAsync();
            Assert.AreEqual(10, res.Result.Activities.Count);
        }

        [TestMethod]
        public void GetAllActivitiesAsyncTest2()
        {
            var res = _ops.GetAllActivitiesAsync(1, 11);
            Assert.AreEqual(11, res.Result.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest()
        {
            var res = _ops.GetUserActivitiesAsync();
            Assert.AreEqual(10, res.Result.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest2()
        {
            var res = _ops.GetUserActivitiesAsync(1, 11);
            Assert.AreEqual(11, res.Result.Activities.Count);
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest3()
        {
            var res = _ops.GetUserActivitiesAsync("coolya");
        }

        [TestMethod]
        public void GetUserActivitiesAsyncTest4()
        {
            var res = _ops.GetUserActivitiesAsync("coolya", 1, 11);
        }
    }
}
