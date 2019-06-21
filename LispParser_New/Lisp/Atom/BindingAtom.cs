using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 继承自BaseAtom，实现了Run方法
/// Run方法中将会对以下三种东西进行绑定：
///     1. Signal——即参数符号
///     2. Template——即模板符号
///     3. Args——即传参，这个是考虑到嵌套lambda表达式中，传参可以是前面已经绑定过的参数
/// </summary>
public abstract class BindingAtom : BaseAtom
{
    public BindingAtom(LispParser parser, string signalsStr, string templateStr) : base(parser, signalsStr, templateStr)
    {
    }

    public override BaseAtom Run(string list)
    {
        // 解析list中的参数
        string[] args = GetArgs(list);

        // 先对args进行绑定，因为可能args中有些东西已经被定义过了
        BindingArgs(args);
        // @TODO: 对SignalsDict进行Signal的BindingValue进行绑定
        BindingSignalValue(args);
        // @TODO：向RuntimeAtomStack注册此Atom
        Parser.RuntimeAtomStack.RegisterSignals(this);
        // 将此函数注册到运行时栈中
        Parser.RuntimeAtomStack.RegisterAtom(this);

        // 将所有的templateResult交给具体自类处理
        BaseAtom result = this.Handle();
        // @TODO：向RuntimeAtomStack取消注册此Atom
        Parser.RuntimeAtomStack.Unregister(this);

        return result;

        // @TODO：对所有Template用运行时栈进行替换
        //BindingTemplateValue();
        //Parser.RuntimeAtomStack.RegisterTemplate(this);
    }

    /// <summary>
    /// 此函数由具体子类实现，用以将所有东西绑定以后，子类决定如何使用它们
    /// </summary>
    protected abstract BaseAtom Handle();


    /// <summary>
    /// 解析指定的已绑定Value的Template
    /// </summary>
    protected BaseAtom ParseTemplate(Template template)
    {
        BaseAtom result = null;
        result = Parser.ParseAndGetAtom(template.BindingValue);
        return result;
    }
    /// <summary>
    /// 解析所有的已绑定的Template
    /// </summary>
    /// <returns></returns>
    protected BaseAtom[] ParseTemplateAll()
    {
        BaseAtom[] results = new BaseAtom[Templates.Length];
        for (int i = 0; i < Templates.Length; i++)
        {
            results[i] = ParseTemplate(Templates[i]);
        }
        return results;
    }


    #region 绑定相关
    private void BindingArgs(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            args[i] = Parser.ParseAndGetResult(args[i]) as string;
        }
    }

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


    ///// <summary>
    ///// 绑定TemplateValue，如果是非原子不会进行绑定
    ///// </summary>
    //private void BindingTemplateValue()
    //{
    //    for (int i = 0; i < Templates.Length; i++)
    //    {
    //        Template template = Templates[i];
    //        string toBindingValue = template.Name;

    //        // 如果非原子，则从库中取出
    //        if (LispUtil.IsAtom(toBindingValue))
    //        {
    //            // 先从Atom调用栈中取出数值
    //            string temp = BindFromRuntimeStack(toBindingValue);
    //            if (temp != null)
    //            {
    //                toBindingValue = temp;
    //            }
    //        }
    //        template.BindingValue = toBindingValue;
    //    }
    //}

    #endregion
}