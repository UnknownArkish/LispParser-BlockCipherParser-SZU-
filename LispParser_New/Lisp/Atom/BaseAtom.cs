using System;
using System.Collections.Generic;
using System.Linq;



public class Signal
{
    /// <summary>
    /// 参数编号
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// 标识名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 绑定的参数数值
    /// </summary>
    public string BindingValue { get; set; }
}
public class Template
{
    public int Index { get; set; }
    /// <summary>
    /// 模板的名字
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 绑定的数值
    /// </summary>
    public string BindingValue { get; set; }
}

/// <summary>
/// 所有函数原子的基类
/// </summary>
public abstract class BaseAtom
{
    public LispParser Parser { get; private set; }

    /// <summary>
    /// 接收参数个数
    /// </summary>
    public int SignalNum { get { return m_SignalDict.Count; } }


    private string m_SignalStr;
    /// <summary>
    /// Signal字典
    /// </summary>
    private Dictionary<string, Signal> m_SignalDict;
    /// <summary>
    /// 返回此函数原子的所有Signals
    /// </summary>
    public Signal[] Signals { get { return m_SignalDict.Values.ToArray(); } }


    private string m_TemplateStr;
    /// <summary>
    /// 操作数Template
    /// </summary>
    private Template m_Operator;
    /// <summary>
    /// Template字典
    /// </summary>
    private Dictionary<int, Template> m_TemplateDict;
    /// <summary>
    /// 返回此函数原子的所有Template
    /// </summary>
    public Template[] Templates { get { return m_TemplateDict.Values.ToArray(); } }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="signalsStr">形如(x y)</param>
    /// <param name="templateStr">形如(??? x y)</param>
    public BaseAtom(LispParser parser, string signalsStr, string templateStr)
    {
        Parser = parser;
        m_SignalDict = new Dictionary<string, Signal>();
        m_TemplateDict = new Dictionary<int, Template>();

        LoadSignalStr(signalsStr);
        LoadTemplateStr(templateStr);
    }
    private void LoadSignalStr(string signalStr)
    {
        m_SignalStr = signalStr;
        m_SignalDict.Clear();

        signalStr = LispUtil.RemoveBracket(signalStr);
        if (string.IsNullOrEmpty(signalStr)) return;
        string[] signalStrs = signalStr.Split(' ');
        //SignalNum = signalStrs.Length;
        for (int i = 0; i < signalStrs.Length; i++)
        {
            m_SignalDict[signalStrs[i]] = new Signal()
            {
                Index = i,
                Name = signalStrs[i],
                BindingValue = null
            };
        }
    }
    private void LoadTemplateStr(string templateStr)
    {
        m_TemplateStr = templateStr;
        m_TemplateDict.Clear();

        templateStr = LispUtil.RemoveBracket(templateStr);
        if (string.IsNullOrEmpty(templateStr)) return;
        string[] templateStrs = LispUtil.SplitInAtomAll(templateStr);

        for (int i = 0; i < templateStrs.Length; i++)
        {
            Template template = new Template
            {
                Index = i - 1,
                Name = templateStrs[i],
                BindingValue = templateStrs[i]
            };
            if (i == 0)
            {
                m_Operator = template;
            }
            else
            {
                m_TemplateDict[i - 1] = template;
            }
        }
    }


    public object Run(string list)
    {
        // @TODO: 解析list中的参数
        string[] args = GetArgs(list);
        // 对所有的arg进行一次ParseList

        // @TODO: 对SignalsDict进行Signal的BindingValue进行绑定
        BindingSignalValue(args);
        // @TODO：向RuntimeAtomStack注册此Atom
        Parser.RuntimeAtomStack.RegisterSignals(this);
        // @TODO：对所有Template<替换>以后进行<ParserList>
        BindingTemplateValue();
        Parser.RuntimeAtomStack.RegisterTemplate(this);
        Parser.RuntimeAtomStack.RegisterAtom(this);

        // 将所有的templateResult交给具体自类处理
        object result = this.Handle(m_Operator);
        // @TODO：向RuntimeAtomStack取消注册此Atom
        Parser.RuntimeAtomStack.Unregister(this);

        return result;
    }

    protected abstract object Handle(Template operand, params object[] args);

    /// <summary>
    /// 绑定Signal
    /// </summary>
    private void BindingSignalValue(string[] args)
    {
        foreach (Signal signal in Signals)
        {
            signal.BindingValue = args[signal.Index];
        }
    }
    /// <summary>
    /// 绑定TemplateValue，如果是非原子不会进行绑定
    /// </summary>
    private void BindingTemplateValue()
    {
        for (int i = 0; i < Templates.Length; i++)
        {
            Template template = Templates[i];
            string toBindingValue = template.Name;

            // 如果非原子，则从库中取出
            if (LispUtil.IsAtom(toBindingValue))
            {
                // 先从Atom调用栈中除去数值
                string temp = Parser.RuntimeAtomStack.GetSignalValue(toBindingValue);
                if (temp != null)
                {
                    toBindingValue = temp;
                }
            }
            template.BindingValue = toBindingValue;
        }
    }
    /// <summary>
    /// 解析指定的已绑定Value的Template
    /// </summary>
    protected object ParseTemplate(Template template)
    {
        object result = template.BindingValue;
        if (LispUtil.IsAtom(template.BindingValue))
        {
            BaseAtom atom = Parser.AtomStorage[template.BindingValue];
            if (atom != null)
            {
                result = atom.Run(template.BindingValue);
            }
        }
        else
        {
            result = Parser.ParserList(template.BindingValue);
        }
        return result;
    }
    /// <summary>
    /// 解析所有的已绑定的Template
    /// </summary>
    /// <returns></returns>
    protected object[] ParseTemplateAll()
    {
        object[] results = new object[Templates.Length];
        for (int i = 0; i < Templates.Length; i++)
        {
            results[i] = ParseTemplate(Templates[i]);
        }
        return results;
    }


    private string[] GetArgs(string list)
    {
        string[] args = LispUtil.SplitInAtom(list, SignalNum + 1);
        string[] result = new string[SignalNum];
        for (int i = 0; i < SignalNum; i++)
        {
            result[i] = args[i + 1];
        }
        return result;
    }


}
