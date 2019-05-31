using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CondAtom : BaseAtom
{
    public CondAtom(LispParser parser) : base(parser, "()", "()")
    {
    }

    public override object GetResult()
    {
        throw new NotImplementedException();
    }

    protected override BaseAtom Handle(Template operand)
    {
        throw new NotImplementedException();
    }

    public override BaseAtom Run(string list)
    {
        BaseAtom result = null;
        string resultToBind = null;

        string[] args = LispUtil.SplitInAtomAll(list);
        for (int i = 1; i < args.Length; i++)
        {
            CondArgsParser condArgsParser = new CondArgsParser(Parser, args[i]);
            if( condArgsParser.ArgIsTrue)
            {
                resultToBind = condArgsParser.ArgResult;
                break;
            }
        }
        // @TODO：绑定resultToBind到result
        if( Parser.RuntimeAtomStack.IsHaveSignalValue(resultToBind))
        {
            resultToBind = BindFromRuntimeStack(resultToBind);
        }
        result = Parser.ParseAndGetAtom(resultToBind);
        return result;
    }

    private string ParseCond(string cond)
    {
        string temp = LispUtil.RemoveBracket(cond);
        string[] condContents = LispUtil.SplitInAtomAll(temp);
        string condResult = Parser.ParseAndGetResult(condContents[0]) as string;
        return null;
    }

}

class CondArgsParser
{
    private LispParser Parser { get; set; }
    public bool ArgIsTrue { get;private set; }
    public string ArgResult { get;private set; }

    public CondArgsParser(LispParser parser, string condArg)
    {
        Parser = parser;
        ParseCondArg(condArg);
    }

    private void ParseCondArg(string condArg)
    {
        string temp = LispUtil.RemoveBracket(condArg);
        string[] argContent = LispUtil.SplitInAtomAll(temp);
        string argCond = Parser.ParseAndGetResult(argContent[0]) as string;

        ArgResult = argContent[1];
        ArgIsTrue = argCond.Equals("True");
    }
}