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
    public class CardTest
    {
       static ICardOperations _ops= new Geeklist.Connect
               .GeeklistServiceProvider("6S8YzYWymDGfb6mB8VPR5Wj_03M", "sz0Wp8bzq_U_Fgsum7XBJrUWSIuIBCvIpoR8PMpMCts")
               .GetApi("mXTwZHawIxlOTf-rP9WpplrFERE", "FiVyVFRIrAILzkZ2TTflQu1uNrMJKnREISS1NiwBzEA").CardOperations;

        [TestMethod]
        public void GetUserCardsTest()
        {
            var res = _ops.GetUserCards();
        }

        [TestMethod]
        public void GetUserCardsTest2()
        {
            var res = _ops.GetUserCards(1, 2);
        }

        [TestMethod]
        public void GetUserCardsTest3()
        {
            var res = _ops.GetUserCards("coolya");
        }

        [TestMethod]
        public void GetUserCardsTest4()
        {
            var res = _ops.GetUserCards("coolya", 1, 2);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest()
        {
            var res = _ops.GetUserCardsAsync();

            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest2()
        {
            var res = _ops.GetUserCardsAsync(1, 2);
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest3()
        {
            var res = _ops.GetUserCardsAsync("coolya");
            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void GetUserCardsAsyncTest4()
        {
            var res = _ops.GetUserCardsAsync("coolya", 1, 2);


            Assert.IsNotNull(res.AsTask().Result);
        }

        [TestMethod]
        public void CreateCardTest()
        {
            var res = _ops.CreateCard("woohooo" + Guid.NewGuid()); // a card from the api " + Guid.NewGuid());
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void CreateCardAsyncTest()
        {
            var res = _ops.CreateCardAsync("woohooo" + Guid.NewGuid());
            Assert.IsNotNull(res.AsTask().Result);
        }
    }
}
