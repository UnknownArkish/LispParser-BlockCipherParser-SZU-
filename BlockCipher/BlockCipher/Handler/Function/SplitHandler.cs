using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace BlockCipher
{
    public class SplitHandler : BaseHandler
    {
        /// <summary>
        /// 切割的变量字符串
        /// </summary>
        public string VariableKey { get; private set; }
        /// <summary>
        /// 切割份数
        /// </summary>
        public int SplitCount { get; private set; }

        public string[] CodeContext { get; private set; }

        public SplitHandler(
            BlockCipherParser parser, string splitCode, string[] codeContext) : base(parser)
        {
            CodeContext = codeContext;

            // @TOOD: 解析得到SplitKey和SplitCount
            Regex reg = new Regex(@"(?<=\().+(?=\))");
            Match match = reg.Match(splitCode);
            string splitContext = match.Value.Trim();
            string[] splitContexts = splitContext.Split(',');

            VariableKey = splitContexts[0].Trim();
            SplitCount = int.Parse(splitContexts[1].Trim());
        }


        public void Run()
        {
            // 切割变量
            SplitVariableAndRegister();

            // 解析SPLIT和MERGE中的代码
            Parser.ParseCodeContext(CodeContext);

            // 合并变量，并删除临时变量
            MergeAndUnregister();
        }

        /// <summary>
        /// 分割并注册变量
        /// </summary>
        private void SplitVariableAndRegister()
        {
            string temp = BindingVariable(VariableKey);
            BitArray variableValue = Parser.VariableStorage[temp];
            int lenPerVariable = variableValue.Length / SplitCount;

            for (int i = 0; i < SplitCount; i++)
            {
                // 切割变量的key
                string splitKey = string.Format("{0}[{1}]", temp, i);
                // 切割的变量数值
                BitArray splitVariable = new BitArray(lenPerVariable);
                for (int j = 0; j < lenPerVariable; j++)
                {
                    splitVariable[j] = variableValue[i * lenPerVariable + j];
                }
                // 注册变量
                Parser.VariableStorage.AddVariable(splitKey, splitVariable);
            }
        }
        /// <summary>
        /// 合并并取消注册变量
        /// </summary>
        private void MergeAndUnregister()
        {
            string temp = BindingVariable(VariableKey);
            BitArray variableValue = Parser.VariableStorage[temp];
            int lenPerVariable = variableValue.Length / SplitCount;

            for( int i = 0; i < SplitCount; i++)
            {
                string splitKey = string.Format("{0}[{1}]", temp, i);
                BitArray splitVariable = Parser.VariableStorage[splitKey];

                for( int j = 0; j < lenPerVariable; j ++)
                {
                    variableValue[i * lenPerVariable + j] = splitVariable[j]; 
                }

                Parser.VariableStorage.RemoveVariable(splitKey);
            }
        }

    }
}
