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

        static IMicroOperations _ops = new Geeklist.Connect
               .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
               .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").MicroOperations;

        [TestMethod]
        public void CreateMicroTest()
        {
            var res = _ops.CreateMicro("Test" + Guid.NewGuid());

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateMicroTest2()
        {
            var rekatzMicro = _ops.CreateMicro("Test" + Guid.NewGuid());
            var res = _ops.CreateMicro("Test" + Guid.NewGuid(), rekatzMicro.Micro.Type, rekatzMicro.Micro.Id);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateMicroAsyncTest()
        {
            var res = _ops.CreateMicroAsync("Test" + Guid.NewGuid());
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void CreateMicroAsyncTest2()
        {
            var rekatzMicro = _ops.CreateMicro("Test" + Guid.NewGuid());
            var res = _ops.CreateMicroAsync("Test" + Guid.NewGuid(), rekatzMicro.Micro.Type, rekatzMicro.Micro.Id);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserMicrosTest()
        {
            var res = _ops.GetUserMicros();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosTest2()
        {
            var res = _ops.GetUserMicros(1, 11);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosTest3()
        {
            var res = _ops.GetUserMicros("rekatz");
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosTest4()
        {
            var res = _ops.GetUserMicros("rekatz", 1 ,11);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest()
        {
            var res = _ops.GetUserMicrosAsync();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest2()
        {
            var res = _ops.GetUserMicrosAsync(1, 11);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest3()
        {
            var res = _ops.GetUserMicrosAsync("rekatz");
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUserMicrosAsyncTest4()
        {
            var res = _ops.GetUserMicrosAsync("rekatz", 1, 11);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMicroTest()
        {
            var rekatzMicro = _ops.GetUserMicros("rekatz").MicrosDetails.Micros[0];

            var res = _ops.GetMicro(rekatzMicro.Id);
            Assert.IsNotNull(res);

            //todo compare each field
        }

        [TestMethod]
        public void GetMicroAsyncTest()
        {
            var rekatzMicro = _ops.GetUserMicros("rekatz").MicrosDetails.Micros[0];

            var res = _ops.GetMicroAsync(rekatzMicro.Id);
            Assert.IsNotNull(res.Result);

            //todo compare each field
        }

    }
}

