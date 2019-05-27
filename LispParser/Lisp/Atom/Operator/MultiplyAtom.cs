using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public class MultiplyAtom : BinaryOperatorAtom
    {
        public MultiplyAtom(LispParser parser) : base(parser)
        {
        }

        protected override object Calculate(object op0, object op1)
        {
            return (int.Parse(op0 as string) * int.Parse(op1 as string)).ToString();
        }
    }
}
