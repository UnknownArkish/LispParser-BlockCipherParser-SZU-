using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2.LispParser
{
    public abstract class LispAtom
    {
        public abstract object Run(params object[] args); 
    }

    public class IntAtom : LispAtom
    {
        public int Data { get; set; }
        public override object Run(params object[] args)
        {
            return Data;
        }
    }

    public class AddAtom : LispAtom
    {
        public override object Run(params object[] args)
        {
            return (int)args[0] + (int)args[1];
        }
    }
}
