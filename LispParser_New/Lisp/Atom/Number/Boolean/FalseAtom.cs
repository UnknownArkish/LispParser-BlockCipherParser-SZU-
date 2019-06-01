using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 同IntAtom
/// </summary>
public class FalseAtom : BaseAtom
{
    public FalseAtom(LispParser parser) : base(parser, "()", "()")
    {
    }

    public override string GetResult()
    {
        return "False";
    }

    public override BaseAtom Run(string list)
    {
        return this;
    }
}