using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _claimsQueue = new Queue<Claims>();

        public Queue<Claims> SeeAllClaims()
        {
            return _claimsQueue;
        }

        public Claims GetNextClaim()
        {
            Claims nextClaim = _claimsQueue.Dequeue();
            return nextClaim;
        }

        public Claims PeekNextClaim()
        {
            foreach(Claims c in _claimsQueue)
            {
                if(c != null)
                {
                    return _claimsQueue.Peek();
                }
            }
            return null;
        }

        public void AddNewClaim(Claims claim)
        {
            _claimsQueue.Enqueue(claim);
        }
    }
}
