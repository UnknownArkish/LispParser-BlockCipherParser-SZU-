﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MultiplyAtom : BinaryOperatorAtom
{
    public MultiplyAtom(LispParser parser) : base(parser)
    {
    }

    protected override int Calculate(int op1, int op2)
    {
        return op1 * op2;
    }
}