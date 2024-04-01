using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveProcess
{
    /// <summary>
    /// 审批者抽象
    /// </summary>
    public interface IApprover
    {
        IApprover next { get; set; }

        void SetNext(IApprover next);

        void ProcessRequest(PurchaseRequest request);
    }
}
