using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{

    public class LambdaAtomFactory : LispAtom
    {
        public LambdaAtomFactory(LispParser parser) : base(parser)
        {
        }

        protected override int ArgNum => 2;

        /// <summary>
        /// 返回一个LambdaAtom
        /// </summary>
        public override object Run(string list)
        {
            // 第一个参数是参数，第二个参数是计算表达式
            string[] args = GetArgs(list);
            string signals = args[0];
            string template = args[1];
            LambdaAtom result = new LambdaAtom(Parser, signals, template);
            return result;
        }

        ///// <summary>
        ///// 解析得到一个LambdaAtom
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //private LambdaAtom ParseLambdaAtom(string list)
        //{
        //    string[] args = GetArgs(list);
        //    int lambdaArgNum = GetLambdaArgNum(args[0]);
        //    LambdaAtom result = new LambdaAtom(Parser, lambdaArgNum, args[1]);
        //    // @TODO: 添加Signals

        //    return result;
        //}

        ///// <summary>
        ///// 得到lambda的参数个数
        ///// </summary>
        //private int GetLambdaArgNum(string arg)
        //{
        //    arg = LispUtil.RemoveBracket(arg);
        //    return arg.Split(' ').Length;
        //}
        //private LispAtom GetLispAtom(string arg)
        //{
        //    arg = LispUtil.RemoveBracket(arg);
        //    string[] args = arg.Split(' ');
        //    return Parser.AtomStorage[args[0]];
        //}
    }
}
