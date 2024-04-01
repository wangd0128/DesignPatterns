using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlowCardTest.流转卡
{
    
    public class ProcessHandleBuilder
    {
        private IProcessHandle head { get; set; }
        private List<IProcessHandle> handles { get; set; } = new List<IProcessHandle>();
        private IProcessHandle tail { get; set; }

        public ProcessHandleBuilder SetNext(IProcessHandle next)
        {
            if(head == null)
            {
                head = next;
            }
            else
            {
                tail.next = next;
            }
            tail = next;
            handles.Add(next);
            return this;
        }

        public void StartProcess(FlowCard flowCard)
        {
            Task.Run(() =>
            {
                handles[flowCard.currentOp]?.Handle(flowCard);
            });
        }

    }
}
