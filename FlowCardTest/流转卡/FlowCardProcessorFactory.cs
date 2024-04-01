using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlowCardTest.流转卡
{
    public class FlowCardProcessorFactory
    {

        public static ProcessHandleBuilder CreateFlowCardBuilder(FlowCard flowCard)
        {
            ProcessHandleBuilder builder = new ProcessHandleBuilder();
            for (int i = 0; i < flowCard.processArray.Count(); i++)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var types = assembly.GetTypes().Where(p => typeof(IProcessHandle).IsAssignableFrom(p));
                var handle_type = types.FirstOrDefault(p =>
                {
                    var attrbute = p.GetCustomAttribute<ProcessHanldeTypeAttribute>();
                    return attrbute?.processType == flowCard.processArray[i].processType;
                });
                if (handle_type != null)
                {
                    IProcessHandle handle_instance = assembly.CreateInstance(handle_type.FullName) as IProcessHandle;
                    handle_instance.SetOp(i);
                    builder.SetNext(handle_instance);
                }
            }
            return builder;
        }

    }
}
