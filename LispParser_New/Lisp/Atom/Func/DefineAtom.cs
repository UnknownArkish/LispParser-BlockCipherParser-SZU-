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

    protected override object Handle(Template operand, params object[] args)
    {
        string key = Templates[0].BindingValue;
        string defineFrom = Templates[1].BindingValue;

        if (!LispUtil.IsAtom(defineFrom))
        {
            // 如果不是原子，说明defineFrom是一个lambda表达式
            // 则调用Parser的ParseList函数，得到一个BaseAtom
            object atomResult = Parser.ParserList(defineFrom);
            if (defineFrom.Contains("lambda"))
            {

            }
            else
            {
                Parser.AtomStorage.Define(key, atomResult as string);
            }
        }
        else
        {
            Parser.AtomStorage.Define(key, defineFrom);
        }
        return "define";
    }
}