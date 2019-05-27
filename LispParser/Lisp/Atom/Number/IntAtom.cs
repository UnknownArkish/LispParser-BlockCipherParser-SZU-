using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public class IntAtom : LispAtom
    {
        public string Data { get; }

        protected override int ArgNum => 0;

        public override object Run(string list)
        {
            return Data;
        }

        public IntAtom(LispParser parser, string data) : base(parser)
        {
            Data = data;
        }
    }
}
