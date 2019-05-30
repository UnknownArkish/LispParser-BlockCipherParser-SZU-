using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LambdaAtomFactory : BaseAtom
{
    public LambdaAtomFactory(LispParser parser) : base(parser, ("(x y)"), ("x y"))
    {
    }

    public override BaseAtom Run(string list)
    {
        string lambdaContent = LispUtil.SplitInAtom(list);
        bool shouldRunResult = false;
        if( !LispUtil.IsAtom(lambdaContent))
        {
            lambdaContent = LispUtil.RemoveBracket(lambdaContent);
            shouldRunResult = true;
        }
        else
        {
            lambdaContent = list;
            shouldRunResult = false;
        }
        // 解析得到LambdaAtom
        string[] args = GetArgs(lambdaContent);
        LambdaAtom lambdaAtom = new LambdaAtom(Parser, args[0], args[1]);

        // @TODO: 如果list后面没有内容，则直接返回这个LambdaAtom
        if (!shouldRunResult)
        {
            return lambdaAtom;
        }
        else
        {
            return lambdaAtom.Run(list);
        }
    }

    public override object GetResult()
    {
        throw new NotImplementedException();
    }

    protected override BaseAtom Handle(Template operand)
    {
        throw new NotImplementedException();
    }
}

public class LambdaAtom : BaseAtom
{
    public LambdaAtom(LispParser parser, string signalsStr, string templateStr) : base(parser, signalsStr, templateStr)
    {
    }

    public override object GetResult()
    {
        throw new NotImplementedException();
    }

    protected override BaseAtom Handle(Template operand)
    {
        BaseAtom atom = Parser.AtomStorage[operand.Name];
        BaseAtom[] templateResults = ParseTemplateAll();
        string[] resuls = new string[templateResults.Length];
        for( int i = 0; i < templateResults.Length; i++)
        {
            resuls[i] = templateResults[i].GetResult() as string;
        }
        StringBuilder sb = new StringBuilder(operand.Name);
        foreach( string result in resuls)
        {
            sb.Append(' ');
            sb.Append(result);
        }
        return atom.Run(sb.ToString());
        return null;
    }
}