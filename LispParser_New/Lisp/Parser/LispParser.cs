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
        // 判断list是否为原子，如果是原子，则直接从原子库中获取
        if (LispUtil.IsAtom(list))
        {
            // 如果RuntimeAtomStack中有，则先绑定
            if( RuntimeAtomStack.IsHaveSignalValue(list))
            {
                list = RuntimeAtomStack.GetSignalValue(list);
            }
            BaseAtom atom = AtomStorage[list];
            return atom;
        }
        // 否则是列表，则调用对应的原子进行运算
        else
        {
            list = LispUtil.RemoveBracket(list);
            string key = LispUtil.SplitInAtom(list);
            BaseAtom atom = AtomStorage[key];
            return atom.Run(list);
        }
    }
}