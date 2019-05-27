using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public abstract class BinaryOperatorAtom : LispAtom
    {
        public BinaryOperatorAtom(LispParser parser) : base(parser)
        {
        }

        protected override int ArgNum => 2;

        public override object Run(string list)
        {
            string[] args = GetArgs(list);
            object op0 = ParseList(args[0]);
            object op1 = ParseList(args[1]);
            return Calculate(op0, op1);
        }

        protected abstract object Calculate(object op0, object op1);
    }
}
