using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IntAtom : BaseAtom
{
    public string Number { get;private set; }

    public IntAtom(LispParser parser, string number) : base(parser, "()", "()")
    {
        Number = number;
    }

    protected override object Handle(Template operand, params object[] args)
    {
        return Number;
    }
}