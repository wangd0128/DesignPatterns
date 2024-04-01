using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowCardTest.流转卡
{
    public enum PROCESS_TYPE
    {
        Start,
        Bake,
        Standard,
        Quality,
        End
    }

    public class PROCESS
    {

        public PROCESS(PROCESS_TYPE processType, string Name)
        {
            this.processType = processType;
            this.Name = Name;
        }
        public PROCESS_TYPE processType { get; set; }

        public string Name { get; set; }
    }
}
