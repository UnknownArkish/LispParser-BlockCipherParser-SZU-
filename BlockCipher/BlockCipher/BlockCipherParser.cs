using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlockCipher
{
    /// <summary>
    /// 分组加密算法解释器
    /// 不接受标准输入，只能通过初始化的形式初始化参数
    /// 如置换盒和S盒等
    /// </summary>
    public class BlockCipherParser
    {
        /// <summary>
        /// 未经任何处理的上下文
        /// </summary>
        private string[] RawContext { get; set; }

        /// <summary>
        /// 变量上下文
        /// </summary>
        private string[] VariableContext { get; set; }
        /// <summary>
        /// 代码上下文
        /// </summary>
        private string[] CodeContext { get; set; }

        /// <summary>
        /// 置换、S箱库存
        /// </summary>
        public PermuteSBoxStorage PermuteSBoxStorage { get; private set; }

        /// <summary>
        /// 变量库存
        /// </summary>
        public VariableStorage VariableStorage { get; private set; }
        /// <summary>
        /// 循环变量库存
        /// </summary>
        public LoopVariableStorage LoopVariableStorage { get; private set; }

        /// <summary>
        /// 表达式解析器
        /// </summary>
        public ExpressionParser ExpressionParser { get; private set; }

        /// <summary>
        /// 初始化一个BlockCipherParser，不会运行
        /// </summary>
        /// <param name="permuteStorages">置换盒</param>
        /// <param name="sBoxStorages">S箱</param>
        /// <param name="rawContext">未经处理的上下文</param>
        public BlockCipherParser(PSData[] permuteStorages, PSData[] sBoxStorages, string[] rawContext)
        {
            PermuteSBoxStorage = new PermuteSBoxStorage(permuteStorages, sBoxStorages);
            VariableStorage = new VariableStorage();
            LoopVariableStorage = new LoopVariableStorage();
            ExpressionParser = new ExpressionParser(this);

            // 解释处理rawContextt
            ParseRawContext(rawContext);
            // 加载（静态）变量
            LoadVariables();
        }

        /// <summary>
        /// 解析未经处理的原代码
        /// </summary>
        private void ParseRawContext(string[] rawContext)
        {
            List<string> variableContext = new List<string>();
            List<string> codeContext = new List<string>();

            int indexOfBEGIN = BlockCipherUtil.FindFirstOf(rawContext, "BEGIN");
            int indexOfEND = BlockCipherUtil.FindLastOf(rawContext, "END");
            for( int i = 0; i < indexOfBEGIN; i++)
            {
                if (!string.IsNullOrEmpty(rawContext[i]))
                    variableContext.Add(rawContext[i]);
            }
            for (int i = indexOfBEGIN; i <= indexOfEND; i++)
            {
                if (!string.IsNullOrEmpty(rawContext[i]))
                    codeContext.Add(rawContext[i]);
            }

            VariableContext = variableContext.ToArray();
            CodeContext = codeContext.ToArray();

            RawContext = rawContext;
        }

        /// <summary>
        /// 加载静态变量
        /// </summary>
        private void LoadVariables()
        {
            foreach(string variableContext in VariableContext)
            {
                string variableKey = Regex.Match(variableContext, "(\\w+)").Value;
                int length = int.Parse(Regex.Match(variableContext, "((\\d+))").Value);

                VariableStorage.AddVariable(variableKey, length);
            }
        }

        /// <summary>
        /// 运行一组加密
        /// </summary>
        public void Run(string state, string key)
        {
            InitBeforeRun( state, key );

            // 取出CodeContext中，除了开头BEGIN和结束END的部分
            string[] codeContext = new string[CodeContext.Length - 2];
            for( int i = 1; i  < CodeContext.Length - 1; i++)
            {
                codeContext[i - 1] = CodeContext[i];
            }
            ParseCodeContext(codeContext);

            DisposeAfterRun();
        }

        /// <summary>
        /// 解析一段代码上下文
        /// </summary>
        public void ParseCodeContext(string[] codeContext)
        {
            for( int i = 0; i < codeContext.Length; i++)
            {
                string code = codeContext[i];
                if (code.Contains("SPLIT"))
                {
                    i = HandleSplitContext(code, codeContext);
                }
                else if (code.Contains("LOOP"))
                {
                    i = HandleLoopContext(code, codeContext);
                }
                else
                {
                    ExpressionParser.ParseExpression(code);
                }
            }
        }
        private int HandleLoopContext( string code, string[] codeContext)
        {
            string[] loopContext = BlockCipherUtil.GetLoopCodeContext(codeContext);
            LoopHandler handler = new LoopHandler(this, code, loopContext);
            handler.Run();
            return BlockCipherUtil.FindLastOf(codeContext, "ENDLOOP");
        }
        private int HandleSplitContext( string code, string[] codeContext)
        {
            string[] splitContext = BlockCipherUtil.GetSplitCodeContext(codeContext);
            SplitHandler handler = new SplitHandler(this, code, splitContext);
            handler.Run();
            return BlockCipherUtil.FindLastContain(codeContext, "MERGE");
        }



        /// <summary>
        /// Run之前的初始化
        /// </summary>
        private void InitBeforeRun(string state, string key)
        {
            VariableStorage.AddVariable("state", state);
            VariableStorage.AddVariable("key", key);
        }
        /// <summary>
        /// Run之后的脏数据还原
        /// </summary>
        private void DisposeAfterRun()
        {

        }

        public string GetState()
        {
            return BlockCipherUtil.BitArrayToString(VariableStorage["state"]);
        }
        public string GetKey()
        {
            return BlockCipherUtil.BitArrayToString(VariableStorage["key"]);
        }
    }
}
