using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowCardTest.流转卡
{
    public class ProcessHanldeTypeAttribute : Attribute
    {
        public PROCESS_TYPE processType { get; set; }
        public ProcessHanldeTypeAttribute(PROCESS_TYPE processType)
        {
            this.processType = processType;
        }

    }
}
