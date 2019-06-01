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

    public override string GetResult()
    {
        return "True";
    }

    public override BaseAtom Run(string list)
    {
        return this;
    }
}