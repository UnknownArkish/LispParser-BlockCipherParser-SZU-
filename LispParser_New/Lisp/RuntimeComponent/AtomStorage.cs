using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 保存一些最基本的AtomStorage，这些AtomStorage不能被覆盖
/// </summary>
public class AtomStorage
{
    public LispParser Parser { get; private set; }

    private Dictionary<string, BaseAtom> m_AtomDict;

    public AtomStorage( LispParser parser )
    {
        Parser = parser;

        InitAtomStorage();
    }

    public BaseAtom this[string key]
    {
        get
        {
            BaseAtom result = null;
            if (!ContainKey(key))
            {
                try
                {
                    int value = int.Parse(key);
                    this.RegisterAtom(key, new IntAtom(Parser, key));
                }
                catch (Exception) { }
            }
            if (ContainKey(key))
            {
                result = m_AtomDict[key];
            }
            return result;
        }
    }

    /// <summary>
    /// 判断是否含有以某个key为键值的原子
    /// </summary>
    public bool ContainKey(string key)
    {
        return m_AtomDict.ContainsKey(key);
    }

    /// <summary>
    /// 注册一个Atom
    /// </summary>
    public bool RegisterAtom(string key, BaseAtom atom)
    {
        if (ContainKey(key)) return false;
        m_AtomDict[key] = atom;
        return true;
    }

    public bool Define(string key, string defineFrom)
    {
        BaseAtom atom = this[defineFrom];
        return RegisterAtom(key, atom);
    }


    private void InitAtomStorage()
    {
        m_AtomDict = new Dictionary<string, BaseAtom>();

        BaseAtom addAtom = new AddAtom(Parser);
        m_AtomDict["+"] = addAtom;

        m_AtomDict["define"] = new DefineAtom(Parser);
    }

}