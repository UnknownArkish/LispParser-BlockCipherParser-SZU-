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
            int lambdaArgNum = GetLambdaArgNum(args[0]);
            LispAtom lispAtom = GetLispAtom(args[1]);
            LambdaAtom result = new LambdaAtom(Parser, lambdaArgNum, lispAtom);
            return result;
        }

        /// <summary>
        /// 得到lambda的参数个数
        /// </summary>
        private int GetLambdaArgNum(string arg)
        {
            arg = LispUtil.RemoveBracket(arg);
            return arg.Split(' ').Length;
        }
        private LispAtom GetLispAtom(string arg)
        {
            arg = LispUtil.RemoveBracket(arg);
            string[] args = arg.Split(' ');
            return Parser.AtomStorage[args[0]];
        }
    }


    /// <summary>
    /// 表示Lambda表达式的原子，返回值是一个Atom
    /// </summary>
    public class LambdaAtom : LispAtom
    {
        private int m_LambdaArgNum;
        private LispAtom m_LispAtom;

        public LambdaAtom(LispParser parser, int lambdaArgNum, LispAtom lispAtom) : base(parser)
        {
            m_LambdaArgNum = lambdaArgNum;
            m_LispAtom = lispAtom;
        }
        
        protected override int ArgNum => m_LambdaArgNum;

        /// <summary>
        /// 返回一个Lambda表达式（即一个Func性质的Atom）
        /// </summary>
        public override object Run(string list)
        {
            return m_LispAtom.Run(list);
        }
    }
}
