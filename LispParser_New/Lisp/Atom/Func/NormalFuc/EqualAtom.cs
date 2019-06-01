using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EqualAtom : BindingAtom
{
    public EqualAtom(LispParser parser) : base(parser, "(x y)", "(eq? x y)")
    {
    }

    public override string GetResult()
    {
        return "EqualAtom";
    }

    protected override BaseAtom Handle()
    {
        BaseAtom[] templateResults = ParseTemplateAll();
        BaseAtom result = null;
        if (templateResults[0].GetResult().Equals(templateResults[1].GetResult()))
        {
            result = Parser.AtomStorage["True"];
        }
        else
        {
            result = Parser.AtomStorage["False"];
        }
        return result;
    }
}