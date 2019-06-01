using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 双元操作符Atom基类，仅对Template进行解析得到IntAtom的结果
/// 由子类决定如何进行计算
/// </summary>
public abstract class BinaryOperatorAtom : BindingAtom
{
    public BinaryOperatorAtom(LispParser parser) : base(parser, "(-x -y)", "(operator -x -y)")
    {
    }

    protected override BaseAtom Handle()
    {
        BaseAtom[] templateResults = ParseTemplateAll();
        int result = Calculate(int.Parse(templateResults[0].GetResult()), int.Parse(templateResults[1].GetResult()));
        return Parser.AtomStorage[result.ToString()];
    }

    /// <summary>
    /// 计算op1和op2的结果，由自类具体实现
    /// </summary>
    protected abstract int Calculate(int op1, int op2);

    public override string GetResult()
    {
        return "BinaryOperatorAtom";
    }
}