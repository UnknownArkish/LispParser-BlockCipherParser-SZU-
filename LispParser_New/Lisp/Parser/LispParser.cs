using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Lisp语言解释器
/// </summary>
public class LispParser
{
    public AtomStorage AtomStorage { get; private set; }
    public RuntimeAtomStack RuntimeAtomStack { get; private set; }

    public LispParser()
    {
        AtomStorage = new AtomStorage(this);
        RuntimeAtomStack = new RuntimeAtomStack(this);


        //BaseAtom addAtom = AtomStorage["+"];
        //Console.WriteLine(addAtom.Run("+ 2 3"));

        //BaseAtom defineAtom = AtomStorage["define"];
        //defineAtom.Run("define add +");

        //BaseAtom one = AtomStorage["1"];
        //Console.WriteLine(one.Run("1 2 3"));
    }

    public object ParserList(string list)
    {
        if (LispUtil.IsAtom(list))
        {
            BaseAtom atom = AtomStorage[list];
            return atom.Run(list);
        }
        else
        {
            list = LispUtil.RemoveBracket(list);
            string key = LispUtil.SplitInAtom(list);
            BaseAtom atom = AtomStorage[key];
            return atom.Run(list);
        }
        return null;
    }

    

}