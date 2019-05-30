using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DefineAtom : BaseAtom
{
    public DefineAtom(LispParser parser) : base(parser, "(key defineFrom)", "(define key defineFrom)")
    {
    }

    public override object GetResult()
    {
        return "DefineAtom";
    }

    protected override BaseAtom Handle(Template operand)
    {
        string key = Templates[0].BindingValue;
        string defineFrom = Templates[1].BindingValue;

        BaseAtom defineFromAtom = null;
        if (!LispUtil.IsAtom(defineFrom))
        {
            // 如果不是原子，说明defineFrom是一个lambda表达式
            // 则调用Parser的ParseList函数，得到一个BaseAtom
            defineFromAtom = Parser.ParseAndGetAtom(defineFrom);
        }
        else
        {
            defineFromAtom = Parser.AtomStorage[defineFrom];
        }
        Parser.AtomStorage.RegisterAtom(key, defineFromAtom);
        return this;
    }
}