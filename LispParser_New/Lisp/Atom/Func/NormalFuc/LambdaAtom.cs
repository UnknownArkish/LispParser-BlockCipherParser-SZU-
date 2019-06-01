using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LambdaAtom : BindingAtom
{
    public LambdaAtom(LispParser parser, string signalsStr, string templateStr) : base(parser, signalsStr, templateStr)
    {
    }

    public override string GetResult()
    {
        throw new NotImplementedException();
    }

    protected override BaseAtom Handle()
    {
        BaseAtom atom = Parser.AtomStorage[Operator.Name];
        BaseAtom[] templateResults = ParseTemplateAll();
        string[] resuls = new string[templateResults.Length];
        for( int i = 0; i < templateResults.Length; i++)
        {
            resuls[i] = templateResults[i].GetResult() as string;
        }
        StringBuilder sb = new StringBuilder(Operator.Name);
        foreach( string result in resuls)
        {
            sb.Append(' ');
            sb.Append(result);
        }
        return atom.Run(sb.ToString());
        return null;
    }
}