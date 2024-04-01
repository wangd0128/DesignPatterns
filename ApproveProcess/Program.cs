
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApproveProcess
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            ApproverBuilder builder = new ApproverBuilder();
            builder
                .SetNext<GroupLeader>()
                .SetNext<DepartmentHeader>()
                .SetNext<Manager>()
                .SetNext<Chairman>();
            builder.ProcessRequest(new PurchaseRequest { Price = 10000 });
            Console.ReadLine();
        }

    }
}
