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

    public override string GetResult()
    {
        return "CondAtom";
    }


    public override BaseAtom Run(string list)
    {
        BaseAtom result = null;
        string resultToBind = null;

        string[] args = LispUtil.SplitInAtomAll(list);
        for (int i = 1; i < args.Length; i++)
        {
            // 将每个CondArg交给CondArgsParser处理
            CondArgsParser condArgsParser = new CondArgsParser(Parser, args[i]);
            // 如果CondArgsParser得到的结果是True，说明使用此CondArg的列表
            if( condArgsParser.ArgIsTrue)
            {
                resultToBind = condArgsParser.ArgResult;
                break;
            }
        }
        result = Parser.ParseAndGetAtom(resultToBind);
        return result;
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