using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveProcess
{
    public class GroupLeader : IApprover
    {
        public IApprover next { get; set; }

        public void ProcessRequest(PurchaseRequest request)
        {
            if (request.Price > 0)
            {
                Console.WriteLine($"组长审批了{request.Price}");
            }
            next?.ProcessRequest(request);
        }

        public void SetNext(IApprover next)
        {
            this.next = next;
        }
    }
}
