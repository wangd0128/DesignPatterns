using FlowCardTest.流转卡;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowCardTest
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            FlowCard flowCard = new FlowCard();
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Start, "开始工序"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Bake, "烘烤1"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Standard, "标准1"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Bake, "烘烤2"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Standard, "标准2"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Standard, "标准3"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.Quality, "质检"));
            flowCard.AddProcess(new PROCESS(PROCESS_TYPE.End, "结束工序"));
            flowCard.currentOp = 0;
            var builder = FlowCardProcessorFactory.CreateFlowCardBuilder(flowCard);
            builder.StartProcess(flowCard);

            while (true)
            {
                var str = Console.ReadLine();
                var op = int.TryParse(str, out int _op) ? _op : 0;
                //模拟场景, 每道工序 都是在等待前端 输入 才会流转
                if(op == flowCard.currentOp)
                {
                    flowCard.autoResetEvent.Set();
                }
            }
        }

    }
}
