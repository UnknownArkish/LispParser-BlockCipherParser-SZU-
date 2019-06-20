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
        // 运行、解释所有的Template后
        BaseAtom[] templateResults = ParseTemplateAll();
        string[] resuls = new string[templateResults.Length];
        for( int i = 0; i < templateResults.Length; i++)
        {
            resuls[i] = templateResults[i].GetResult() as string;
        }
        // 开始构造列表
        StringBuilder sb = new StringBuilder( "(" + Operator.Name);
        foreach( string result in resuls)
        {
            sb.Append(' ');
            sb.Append(result);
        }
        sb.Append(")");
        return Parser.ParseAndGetAtom(sb.ToString());
    }
}