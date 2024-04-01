using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveProcess
{
    public class DepartmentHeader : IApprover
    {
        public IApprover next { get; set; }

        public void ProcessRequest(PurchaseRequest request)
        {
            
            if (request.Price >= 100 )
            {
                Console.WriteLine($"部门领导审批了{request.Price}");
            }
            next?.ProcessRequest(request);
        }

        public void SetNext(IApprover next)
        {
            this.next = next;
        }
    }
}
