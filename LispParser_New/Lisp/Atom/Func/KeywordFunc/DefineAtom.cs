using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DefineAtom : BaseAtom
{
    public DefineAtom(LispParser parser) : 
        base(parser, "(key defineFrom)", "(define key defineFrom)")
    {
    }

    public override string GetResult()
    {
        return "DefineAtom";
    }

    public override BaseAtom Run(string list)
    {
        // 获取参数
        string[] args = base.GetArgs(list);
        string key = args[0];
        string defineFrom = args[1];

        BaseAtom defineFromAtom = null;
        // 调用Parser的解释列表的函数，得到一个原子
        defineFromAtom = Parser.ParseAndGetAtom(defineFrom);
        // 将key值和被定义的原子注册到原子库当中
        Parser.AtomStorage.RegisterAtom(key, defineFromAtom);
        return this;
    }
}