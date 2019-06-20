using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 表示加法的原子
/// </summary>
public class AddAtom : BinaryOperatorAtom
{
    public AddAtom(LispParser parser) : base(parser)
    {
    }

    protected override int Calculate(int op1, int op2)
    {
        return op1 + op2;
    }
}