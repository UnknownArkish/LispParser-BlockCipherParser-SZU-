using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LambdaAtom : BindingAtom
{
    public LambdaAtom(LispParser parser, string signalsStr, string templateStr) : base(parser, signalsStr, templateStr)
    {
    }

    public override string GetResult()
    {
        throw new NotImplementedException();
    }

    protected override BaseAtom Handle()
    {
        // 开始构造列表
        StringBuilder sb = new StringBuilder( "(" + Operator.Name);
        foreach( Template template in Templates)
        {
            sb.Append(' ');
            sb.Append(template.BindingValue);
        }
        sb.Append(")");
        return Parser.ParseAndGetAtom(sb.ToString());
    }
}