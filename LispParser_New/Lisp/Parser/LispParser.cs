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
    }

    /// <summary>
    /// 解析并得到结果
    /// </summary>
    public object ParseAndGetResult(string list)
    {
        return ParseAndGetAtom(list).GetResult();
    }

    /// <summary>
    /// 解析得到一个原子
    /// </summary>
    public BaseAtom ParseAndGetAtom(string list)
    {
        if (LispUtil.IsAtom(list))
        {
            BaseAtom atom = AtomStorage[list];
            return atom;
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