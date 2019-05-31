using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TrueAtom : BaseAtom
{
    public TrueAtom(LispParser parser) : base(parser, "()", "()")
    {
    }

    public override object GetResult()
    {
        return "True";
    }

    protected override BaseAtom Handle(Template operand)
    {
        return this;
    }
}