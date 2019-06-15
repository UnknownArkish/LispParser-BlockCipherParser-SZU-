using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BlockCipher
{
    public abstract class BaseHandler
    {
        public abstract BitArray Handle(params BitArray[] datas);
    }
}
