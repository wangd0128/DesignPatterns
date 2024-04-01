using System;

namespace FlowCardTest.流转卡
{
    public interface IProcessHandle
    {
        IProcessHandle next { get; set; }
        void SetOp(int op);
        void SetNext(IProcessHandle next);

        void Handle(FlowCard flowCard);


    }
}