using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowCardTest.流转卡
{
    [ProcessHanldeType(PROCESS_TYPE.Standard)]
    public class ProcessStandardHandle : IProcessHandle
    {
        public int op { get; set; }
        public void SetOp(int op)
        {
            this.op = op;
        }

        public IProcessHandle next { get; set; }
        public void Handle(FlowCard flowCard)
        {
            flowCard.currentOp = op;
            Console.WriteLine($"等待{flowCard.processArray[op].Name} 审核   请录入:{op}");
            flowCard.autoResetEvent.WaitOne();
            Console.WriteLine($"{op} {flowCard.processArray[op].Name} 已完成!");
            next?.Handle(flowCard);
        }

        public void SetNext(IProcessHandle next)
        {
            this.next = next;
        }
    }
}
