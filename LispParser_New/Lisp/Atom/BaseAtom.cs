using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// 定义：
///     一个Signal表示接受什么样的参数，例如：
///     lambda (x y) (+ x y)中，(x y)的x和y都是Signal
/// 作用:
///     用以定位到Template，并根据此来绑定Template的数值
/// </summary>
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
/// <summary>
/// 定义：
///     一个Template表示一个原子或者列表，例如：
///     lambda (x y) (+ x y)中，(+ x y)的+和x和y都是Template
///     lambda (x y) (+ (+ x x) y)中，+、(+ x x)、y是三个Template
/// 作用：
///     被Signal定位，并最终会根据Template绑定的内容进行进一步的计算
/// </summary>
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
/// 任何继承自BaseAtom都可以用两部分组成，分别是Signal和Template，形如lambda (Signal) (Template)
/// 任何东西（包括函数和数值）都可以看作是一个lambda表达式，基于这个原理，BaseAtom实现了以下动作:
///     1. 加载Signal串和Template串，为子类的具体动作提供依据
///     2. 提供了最原始的Run接口，Run接受的是原始的列表
/// </summary>
public abstract class BaseAtom : ICanRun, ICanGetResult
{
    public LispParser Parser { get; private set; }

    private string m_SignalStr;
    private Dictionary<string, Signal> m_SignalDict;

    private string m_TemplateStr;
    private Template m_Operator;
    private Dictionary<int, Template> m_TemplateDict;

    /// <summary>
    /// 接收参数个数
    /// </summary>
    public int SignalNum { get { return m_SignalDict.Count; } }
    /// <summary>
    /// 返回此函数原子的所有Signals
    /// </summary>
    public Signal[] Signals { get { return m_SignalDict.Values.ToArray(); } }
    /// <summary>
    /// 返回操作数的Template
    /// </summary>
    protected Template Operator { get => m_Operator; private set => m_Operator = value; }
    /// <summary>
    /// 返回此函数原子的所有Template（除去操作数Template）
    /// </summary>
    public Template[] Templates { get { return m_TemplateDict.Values.ToArray(); } }


    /****************************************************
     *                    外部接口
     ***************************************************/

    /// <summary>
    /// 解释一个列表表达式，返回一个BaseAtom
    /// </summary>
    public abstract BaseAtom Run(string list);
    /// <summary>
    /// 返回代表此BaseAtom的字符串
    /// </summary>
    public abstract string GetResult();

    /// <summary>
    /// BaseAtom的构造函数
    /// </summary>
    /// <param name="parser">依赖的解释器</param>
    /// <param name="signalsStr">标志字符串，形如( x y )</param>
    /// <param name="templateStr">模板字符串，形如( +  x y )</param>
    public BaseAtom(LispParser parser, string signalsStr, string templateStr)
    {
        Parser = parser;
        m_SignalDict = new Dictionary<string, Signal>();
        m_TemplateDict = new Dictionary<int, Template>();

        LoadSignalStr(signalsStr);                  // 加载标志字符串
        LoadTemplateStr(templateStr);               // 加载模板字符串
    }


    /****************************************************
     *                    内部接口
     ***************************************************/

    private void LoadSignalStr(string signalStr)
    {
        m_SignalStr = signalStr;
        m_SignalDict.Clear();

        signalStr = LispUtil.RemoveBracket(signalStr);
        if (string.IsNullOrEmpty(signalStr)) return;
        string[] signalStrs = signalStr.Split(' ');
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
                Operator = template;
            }
            else
            {
                m_TemplateDict[i - 1] = template;
            }
        }
    }

    /// <summary>
    /// 根据自身的Signal个数切分得到所有的参数
    /// </summary>
    protected string[] GetArgs(string list)
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
