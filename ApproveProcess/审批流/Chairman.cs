using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveProcess
{
    public class Chairman : IApprover
    {
        public IApprover next { get; set; }

        public void ProcessRequest(PurchaseRequest request)
        {
            if(request.Price >= 100000)
            {
                Console.WriteLine($"董事长审批了{request.Price}");
            }
            else
            {
                next?.ProcessRequest(request);
            }
        }

        public void SetNext(IApprover next)
        {
            this.next = next;
        }
    }
}
