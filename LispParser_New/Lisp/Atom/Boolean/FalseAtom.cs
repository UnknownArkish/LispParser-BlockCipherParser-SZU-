using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FalseAtom : BaseAtom
{
    public FalseAtom(LispParser parser) : base(parser, "()", "()")
    {
    }

    public override object GetResult()
    {
        return "False";
    }

    protected override BaseAtom Handle(Template operand)
    {
        return this;
    }
}