using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepo
{
   public class ClaimsRepository
    {
        public Queue<ClaimContent> _claimsQueue = new Queue<ClaimContent>();
        public Queue<ClaimContent> QueueOfClaims { get; set; }
        //1. See all claims
        public Queue<ClaimContent> GetClaimsQueue()
        {
            return _claimsQueue;

        }
        //2. Take care of next claim      
        public void TakeCareOfNextClaim()
        {
            _claimsQueue.Dequeue();
        }
        public ClaimContent DisplayClaim()
        {          
            
           
                return _claimsQueue.Peek();
        }
        //3. Enter a new claim
        public void AddClaimToQueue(ClaimContent newclaim)
        {
            _claimsQueue.Enqueue(newclaim);
        }

        public void loadQueue()

        {
            ClaimContent claim1 = new ClaimContent("1", (ClaimType)1, "Car accident on 465.", Decimal.Parse("400.00"), DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);
            ClaimContent claim2 = new ClaimContent("2", (ClaimType)2, "House fire in kitchen.", Decimal.Parse("4000.00"), DateTime.Parse(" 2018-04-11"), DateTime.Parse("2018-04-12"), true);
            ClaimContent claim3 = new ClaimContent("3", (ClaimType)3, "Stolen pancakes.", decimal.Parse("4.00"), DateTime.Parse("2018-04-27"), DateTime.Parse("2018-06-01"), false); 
            _claimsQueue.Enqueue(claim1);
            _claimsQueue.Enqueue(claim2);
            _claimsQueue.Enqueue(claim3);
        }




    }
}
