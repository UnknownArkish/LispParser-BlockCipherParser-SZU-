using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AddAtom : BinaryOperatorAtom
{
    public AddAtom(LispParser parser) : base(parser)
    {
    }

    protected override object Calculate(string op1, string op2)
    {
        return (int.Parse(op1) + int.Parse(op2)).ToString();
    }

}