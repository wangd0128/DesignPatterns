using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ApproveProcess
{
    public class ApproverBuilder
    {
        private IApprover head;
        private IApprover tail;

        public ApproverBuilder SetNext<T>() where T : IApprover, new()
        {
            var next = new T();
            if (head == null)
            {
                head = next;
            }
            else
            {
                tail.SetNext(next);
            }
            tail = next;
            return this;
        }

        public void ProcessRequest(PurchaseRequest request)
        {
            head?.ProcessRequest(request);
            Console.WriteLine("审批流结束");
        }
    }
}
