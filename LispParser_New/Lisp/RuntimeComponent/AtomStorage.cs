﻿using System;
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
            // 检查是否为整型
            if (!ContainKey(key) && CheckIsNum(key))
            {
                // 如果是则创建此原子，并注册进库中
                this.RegisterAtom(key, new IntAtom(Parser, key));
            }
            if (ContainKey(key))
            {
                result = m_AtomDict[key];
            }
            if( result == null && CheckIsLambdaAtom(key))
            {
                result = m_AtomDict["LambdaFactory"];
            }
            if (result == null && CheckIsCond(key))
            {
                result = m_AtomDict["CondFactory"];
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
        m_AtomDict = new Dictionary<string, BaseAtom>
        {
            ["+"] = new AddAtom(Parser),                        // 加法原子
            ["-"] = new ReduceAtom(Parser),                     // 减法原子
            ["*"] = new MultiplyAtom(Parser),                   // 乘法原子
            ["/"] = new DivideAtom(Parser),                     // 除法原子

            ["True"] = new TrueAtom(Parser),
            ["False"] = new FalseAtom(Parser),

            ["define"] = new DefineAtom(Parser),
            ["LambdaFactory"] = new LambdaAtomFactory(Parser),
            ["eq?"] = new EqualAtom(Parser),
            ["CondFactory"] = new CondAtom(Parser),
        };
    }

    /// <summary>
    /// 检查是否为整型
    /// </summary>
    private bool CheckIsNum(string key)
    {
        try
        {
            int temp = int.Parse(key);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// 检查是否含有lambda表达式
    /// </summary>
    private bool CheckIsLambdaAtom(string key)
    {
        if (!LispUtil.IsAtom(key))
        {
            key = LispUtil.RemoveBracket(key);
        }
        string keyFirstArgs = LispUtil.SplitInAtom(key);
        if (keyFirstArgs.Equals("lambda")) return true;
        return false;
    }
    /// <summary>
    /// 检查是否条件表达式
    /// </summary>
    private bool CheckIsCond(string key)
    {
        string keyFirstArgs = LispUtil.SplitInAtom(key);
        if (keyFirstArgs.Equals("cond")) return true;
        return false;
    }

}