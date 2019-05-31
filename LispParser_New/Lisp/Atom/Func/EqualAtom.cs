using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EqualAtom : BaseAtom
{
    public EqualAtom(LispParser parser) : base(parser, "(x y)", "(eq? x y)")
    {
    }

    public override object GetResult()
    {
        return "EqualAtom";
    }

    protected override BaseAtom Handle(Template operand)
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