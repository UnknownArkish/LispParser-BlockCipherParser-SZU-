using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 运行时的Signal
/// </summary>
public class RuntimeSignal
{
    public string Name { get; set; }
    public string BindingValue { get; set; }
}

/// <summary>
/// 运行时的函数原子栈
/// </summary>
public class RuntimeAtomStack
{
    // 解释器
    public LispParser Parser { get; private set; }
    // 原子运行栈
    private Stack<BaseAtom> m_AtomStack;
    // 原子运行时，向栈中push入Signal的字典
    private Dictionary<string, Stack<RuntimeSignal>> m_RuntimeSignalDict;

    public RuntimeAtomStack(LispParser parser)
    {
        Parser = parser;
        m_RuntimeSignalDict = new Dictionary<string, Stack<RuntimeSignal>>();
        m_AtomStack = new Stack<BaseAtom>();

        //m_RuntimeTemplateDict = new Dictionary<string, Stack<RuntimeTemplate>>();
    }

    /// <summary>
    /// 注册一个BaseAtom中所有（已绑定）参数到运行时原子库栈中
    /// </summary>
    public void RegisterSignals(BaseAtom atom)
    {
        Signal[] signals = atom.Signals;
        foreach(Signal signal in signals)
        {
            PushRuntimeSignal(signal);
        }
    }
    /// <summary>
    /// 注册一个原子，类似于函数调用栈
    /// </summary>
    public void RegisterAtom(BaseAtom atom)
    {
        m_AtomStack.Push(atom);
    }

    public void Unregister(BaseAtom atom)
    {
        Signal[] signals = atom.Signals;
        foreach (Signal signal in signals)
        {
            PopRuntimeSignal(signal);
        }
        m_AtomStack.Pop();

        //Template[] templates = atom.Templates;
        //foreach (Template template in templates)
        //{
        //    PopRuntimeTemplate(template);
        //}
    }

    /// <summary>
    /// 检查是否有对应符号的Value
    /// </summary>
    public bool IsHaveSignalValue(string signalName)
    {
        if (!CheckIsHaveSignalStack(signalName))
        {
            return false;
        }
        Stack<RuntimeSignal> runtimeSignals = m_RuntimeSignalDict[signalName];
        if( runtimeSignals.Count == 0)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// 获取一个符号的Value，如果不存在，返回null
    /// </summary>
    public string GetSignalValue(string signalName)
    {
        string result = null;
        if( IsHaveSignalValue(signalName))
        {
            Stack<RuntimeSignal> runtimeSignals = m_RuntimeSignalDict[signalName];
            result = runtimeSignals.Peek().BindingValue;
        }
        return result;
    }


    private void PushRuntimeSignal(Signal signal)
    {
        if (!CheckIsHaveSignalStack(signal))
        {
            m_RuntimeSignalDict[signal.Name] = new Stack<RuntimeSignal>();
        }
        Stack<RuntimeSignal> runtimeSignals = m_RuntimeSignalDict[signal.Name];
        runtimeSignals.Push(
            new RuntimeSignal()
            {
                Name = signal.Name,
                BindingValue = signal.BindingValue
            }
        );
    }
    private void PopRuntimeSignal(Signal signal)
    {
        Stack<RuntimeSignal> runtimeSignals = m_RuntimeSignalDict[signal.Name];
        runtimeSignals.Pop();
    }


    private bool CheckIsHaveSignalStack(string signalName)
    {
        if (!m_RuntimeSignalDict.ContainsKey(signalName))
        {
            m_RuntimeSignalDict[signalName] = null;
        }
        Stack<RuntimeSignal> runtimeSignals = m_RuntimeSignalDict[signalName];
        return runtimeSignals != null;
    }
    private bool CheckIsHaveSignalStack(Signal signal)
    {
        return CheckIsHaveSignalStack(signal.Name);
    }


    //private Dictionary<string, Stack<RuntimeTemplate>> m_RuntimeTemplateDict;

    //public void RegisterTemplate(BaseAtom atom)
    //{
    //    Template[] templates = atom.Templates;
    //    foreach (Template template in templates)
    //    {
    //        PushRuntimeTemplate(template);
    //    }
    //}

    //public void PushRuntimeTemplate(Template template)
    //{
    //    if (!CheckIsHaveTmplateStack(template))
    //    {
    //        m_RuntimeTemplateDict[template.Name] = new Stack<RuntimeTemplate>();
    //    }
    //    Stack<RuntimeTemplate> runtimeTemplates = m_RuntimeTemplateDict[template.Name];
    //    runtimeTemplates.Push(
    //        new RuntimeTemplate()
    //        {
    //            Name = template.Name,
    //            BindingValue = template.BindingValue
    //        }
    //    );
    //}
    //public void PopRuntimeTemplate(Template template)
    //{
    //    Stack<RuntimeTemplate> runtimeTemplates = m_RuntimeTemplateDict[template.Name];
    //    runtimeTemplates.Pop();
    //    if( runtimeTemplates.Count > 0)
    //    {
    //        template.BindingValue = runtimeTemplates.Peek().BindingValue;
    //    }
    //}


    //private bool CheckIsHaveTmplateStack(string templateName)
    //{
    //    if( !m_RuntimeTemplateDict.ContainsKey(templateName))
    //    {
    //        m_RuntimeTemplateDict[templateName] = null;
    //    }
    //    Stack<RuntimeTemplate> runtimeTemplates = m_RuntimeTemplateDict[templateName];
    //    return runtimeTemplates != null;
    //}
    //private bool CheckIsHaveTmplateStack(Template template)
    //{
    //    return CheckIsHaveTmplateStack(template.Name);
    //}

}