using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// LambdaAtomFactory用以拦截带有lambda表达式的列表
/// 继承自BaseAtom，实现了Run方法：
///     1. 提取原始Run方法的列表，分为两个部分，分别是Signals和Template
///     2. 根据上面的Signal和Template创建一个LambdaAtom
/// </summary>
public class LambdaAtomFactory : BaseAtom
{
    public LambdaAtomFactory(LispParser parser) : base(parser, ("(x y)"), ("x y"))
    {
    }

    public override BaseAtom Run(string list)
    {
        string lambdaContent = LispUtil.SplitInAtom(list);
        bool shouldRunResult = false;
        if (!LispUtil.IsAtom(lambdaContent))
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

    public override string GetResult()
    {
        return "LambdaAtomFactory";
    }
}