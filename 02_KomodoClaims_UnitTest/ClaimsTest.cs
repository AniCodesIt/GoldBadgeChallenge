using System;
using System.Collections.Generic;
using KomodoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KomodoClaims_UnitTest
{
    [TestClass]
    public class ClaimsTest
    {
        ClaimsRepository repoWindow = new ClaimsRepository();

        [TestMethod]
        public void TestLoadQueue()
        {
            repoWindow.loadQueue();
            int tempVar = repoWindow._claimsQueue.Count;
            Assert.AreEqual(3, tempVar);
        }
        [TestMethod]
        public void TestTakeCareOfNextClaim()
        {
            repoWindow.loadQueue();
            repoWindow.TakeCareOfNextClaim();
            int tempVar = repoWindow._claimsQueue.Count;
            Assert.AreEqual(2, tempVar);
        }

        [TestMethod]
        public void TestDisplayClaim()
        {
            repoWindow.loadQueue();
            ClaimContent tempVar = repoWindow.DisplayClaim();
            ClaimContent controlData = new ClaimContent("1", (ClaimType)1, "Car accident on 465.", Decimal.Parse("400.00"), DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);
            Assert.AreEqual(controlData.Description, tempVar.Description);

        }

        [TestMethod]
        public void TestAddClaimToQueue()
        {
            repoWindow.loadQueue();           
            ClaimContent controlData = new ClaimContent("1", (ClaimType)1, "Car accident on 465.", Decimal.Parse("400.00"), DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);
            repoWindow.AddClaimToQueue(controlData);
            int tempVar = repoWindow._claimsQueue.Count;
            Assert.AreEqual(4, tempVar);
        }
        [TestMethod]
        public void TestGetClaimsQueue()
        {
            repoWindow.loadQueue();
            Queue<ClaimContent> tempVar = new Queue<ClaimContent>();
            //tempVar hold the data from GetClaimsQueue
            tempVar = repoWindow.GetClaimsQueue();

            //building out control data
            Queue<ClaimContent> controlData = new Queue<ClaimContent>();
            ClaimContent claim1 = new ClaimContent("1", (ClaimType)1, "Car accident on 465.", Decimal.Parse("400.00"), DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);
            ClaimContent claim2 = new ClaimContent("2", (ClaimType)2, "House fire in kitchen.", Decimal.Parse("4000.00"), DateTime.Parse(" 2018-04-11"), DateTime.Parse("2018-04-12"), true);
            ClaimContent claim3 = new ClaimContent("3", (ClaimType)3, "Stolen pancakes.", decimal.Parse("4.00"), DateTime.Parse("2018-04-27"), DateTime.Parse("2018-06-01"), false);
            controlData.Enqueue(claim1);
            controlData.Enqueue(claim2);
            controlData.Enqueue(claim3);

            //Because these are in queues comparing them would cause a dequeue 
            //and loss of data to testing method - so we compare them in arrays
            ClaimContent[] tempArray = new ClaimContent[tempVar.Count];
            tempVar.CopyTo(tempArray, 0);

            ClaimContent[] controlArray = new ClaimContent[controlData.Count];
            controlData.CopyTo(controlArray, 0);

            //comparing the 2 arrays
            CollectionAssert.AreEqual(controlArray, tempArray);

        }

    }

}
