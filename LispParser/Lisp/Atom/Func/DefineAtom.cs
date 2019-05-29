using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public class DefineAtom : LispAtom
    {
        public DefineAtom(LispParser parser) : base(parser)
        {
        }

        protected override int ArgNum => 2;

        public override object Run(string list)
        {
            string[] args = GetArgs(list);
            if( !LispUtil.IsAtom(args[1]))
            {
                if (args[1].Contains("lambda"))
                {
                    LispAtom lambda = Parser.ParseFunc(args[1]);
                    Parser.AtomStorage.RegisterAtom(args[0], lambda);
                    return null;
                }
                else
                {
                    args[1] = ParseList(args[1]) as string;
                }
            }
            Parser.AtomStorage.Define(args[0], args[1]);
            return null;
        }
    }
}
