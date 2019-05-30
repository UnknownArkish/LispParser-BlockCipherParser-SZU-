using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BinaryOperatorAtom : BaseAtom
{
    public BinaryOperatorAtom(LispParser parser) : base(parser, "(x y)", "(operator x y)")
    {
    }

    protected override object Handle(Template operand, params object[] args)
    {
        object[] templateResults = ParseTemplateAll();
        return Calculate(templateResults[0] as string, templateResults[1] as string);
    }

    protected abstract object Calculate(string op1, string op2);


}