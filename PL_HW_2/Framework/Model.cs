using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2.Framework
{
    public abstract class Model
    {
        public abstract string Name { get; }
        public virtual void Init() { }
    }
}
