using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        private string[] VariablesContext { get; set; }
        /// <summary>
        /// 代码上下文
        /// </summary>
        private string[] CodesContext { get; set; }

        /// <summary>
        /// 置换、S箱库存
        /// </summary>
        public PermuteSBoxStorage PermuteSBoxStorage { get; private set; }

        /// <summary>
        /// 变量库存
        /// </summary>
        public VariableStorage VariableStorage { get; private set; }

        public RuntimeVariableStack RuntimeVariableStack { get; private set; }

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
            RuntimeVariableStack = new RuntimeVariableStack();

            // 解释处理rawContext
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

            int indexOfBEGIN = BlockCipherUtil.FindLastOf(rawContext, "BEGIN");
            int indexOfEND = BlockCipherUtil.FindLastOf(rawContext, "END");
            for( int i = 0; i < indexOfBEGIN; i++)
            {
                variableContext.Add(rawContext[i]);
            }
            for( int i = indexOfBEGIN; i <= indexOfEND; i++)
            {
                codeContext.Add(rawContext[i]);
            }

            VariablesContext = variableContext.ToArray();
            CodesContext = codeContext.ToArray();

            RawContext = rawContext;
        }

        /// <summary>
        /// 加载静态变量
        /// </summary>
        private void LoadVariables()
        {
            foreach(string variableContext in VariablesContext)
            {
                string variableKey = Regex.Match(variableContext, "(\\w+)").Value;
                int length = int.Parse(Regex.Match(variableContext, "((\\d+))").Value);

                VariableStorage.AddVariable(variableContext, length);
            }
        }

        /// <summary>
        /// 运行一组加密
        /// </summary>
        public void Run(string state, string key)
        {
            InitBeforeRun();

            DisposeAfterRun();
        }
        
        /// <summary>
        /// Run之前的初始化
        /// </summary>
        private void InitBeforeRun()
        {

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
