using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public class LambdaSignalArg
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class LambdaTempateArg
    {
        public int Index { get; set; }
        public string Name { get; set; }
    }


    /// <summary>
    /// 表示Lambda表达式的原子，返回值是一个Atom
    /// </summary>
    public class LambdaAtom : LispAtom
    {
        /// <summary>
        /// Lambda的参数个数
        /// </summary>
        private int m_LambdaArgNum;


        /// <summary>
        /// 运算符原子
        /// </summary>
        private LambdaTempateArg m_OperatorAtom;
        /// <summary>
        /// 模板原子字典
        /// </summary>
        private Dictionary<int, LambdaTempateArg> m_TempalteArgDict;
        


        /// <param name="signals"> (x y) </param>
        /// <param name="template">(+ x y)</param>
        public LambdaAtom(LispParser parser, string signals, string template) : base(parser)
        {
            m_LambdaArgNum = -1;
            m_TempalteArgDict = new Dictionary<int, LambdaTempateArg>();
            m_OperatorAtom = null;

            InitSignals(signals);
            InitTemplate(template);
        }
        /// <summary>
        /// 初始化参数和符号表信息
        /// </summary>
        private void InitSignals(string signals)
        {
            signals = LispUtil.RemoveBracket(signals).Trim();
            string[] args = signals.Split(' ');

            // Lambda参数个数
            m_LambdaArgNum = args.Length;
            // 注册符号表
            //for (int i = 0; i < args.Length; i++)
            //{
            //    m_TempalteArgDict[i] = new LambdaTempateArg()
            //    {
            //        Index = i,
            //        //Name = i.ToString(),
            //    };
            //}
            TestSingals();
        }
        private void TestSingals()
        {
            m_TempalteArgDict[0] = new LambdaTempateArg()
            {
                Index = 0,
                Name = "(+ 2 3)"
            };
            m_TempalteArgDict[1] = new LambdaTempateArg()
            {
                Index = 1,
                Name = "5"
            };

        }

        /// <summary>
        /// 初始化模板
        /// </summary>
        private void InitTemplate(string template)
        {
            template = LispUtil.RemoveBracket(template).Trim();
            string[] templateArgs = template.Split(' ');
            m_OperatorAtom = new LambdaTempateArg()
            {
                Index = -1,
                Name = Parser.ParserFuncKey(templateArgs[0])
            };
        }



        protected override int ArgNum => m_LambdaArgNum;

        public override object Run(string list)
        {
            string[] args = GetArgs(list);
            // @TODO: 使用args填充模板原子字典
            // @TODO: 对于每个模板原子，根据args的下标，


            string[] results = new string[m_TempalteArgDict.Count];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = Parser.ParseList(m_TempalteArgDict[i].Name) as string;
            }

            // 将results拼成一个list，交给Operator进行Run操作
            StringBuilder sb = new StringBuilder(m_OperatorAtom.Name);
            for (int i = 0; i < results.Length; i++)
            {
                sb.Append(' ');
                sb.Append(results[i]);
            }
            list = sb.ToString();
            return Parser.ParseList(list);
        }


        //private int m_LambdaArgNum;
        //private LispAtom m_LispAtom;

        //public LambdaAtom(LispParser parser, int lambdaArgNum, LispAtom lispAtom) : base(parser)
        //{
        //    m_LambdaArgNum = lambdaArgNum;
        //    m_LispAtom = lispAtom;
        //}

        //private string m_Template;
        //private Dictionary<int, string> m_SignalDict;
        //public LambdaAtom(LispParser parser, int lambadArgNum, string template) : base(parser)
        //{
        //    m_LambdaArgNum = lambadArgNum;
        //    m_Template = template;
        //    m_SignalDict = new Dictionary<int, string>();
        //}
        //public void AddSignals(int index, string signal)
        //{
        //    m_SignalDict[index] = signal;
        //}


        //protected override int ArgNum => m_LambdaArgNum;

        ///// <summary>
        ///// 返回一个Lambda表达式（即一个Func性质的Atom）
        ///// </summary>
        //public override object Run(string list)
        //{
        //    return m_LispAtom.Run(list);
        //}
    }
}
