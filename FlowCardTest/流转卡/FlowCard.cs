using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowCardTest.流转卡
{
    public class FlowCard
    {
        public List<PROCESS> processArray { get; set; } = new List<PROCESS>();

        public AutoResetEvent autoResetEvent { get; set; } = new AutoResetEvent(false);

        public int currentOp { get; set; } = 0;

        public void AddProcess(PROCESS op)
        {
            processArray.Add(op);
        }

    }
}
