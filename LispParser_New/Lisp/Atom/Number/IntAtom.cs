using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 表示整型数值的函数原子
/// 没有任何Signal也没有任何Template，有意义的仅实现GetResult方法
/// 返回此数值函数原子表示的Number的字符串
/// </summary>
public class IntAtom : BaseAtom
{
    public string Number { get;private set; }

    public IntAtom(LispParser parser, string number) : base(parser, "()", "()")
    {
        Number = number;
    }
    
    public override string GetResult()
    {
        return Number;
    }

    public override BaseAtom Run(string list)
    {
        return this;
    }
}