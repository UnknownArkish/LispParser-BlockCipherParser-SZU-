using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    public class SplitHandler : BaseHandler
    {
        /// <summary>
        /// 切割的变量字符串
        /// </summary>
        public string SplitKey { get; private set; }
        /// <summary>
        /// 切割份数
        /// </summary>
        public int SplitCount { get; private set; }

        public string[] CodeContext { get; private set; }

        public SplitHandler(BlockCipherParser parser, string splitCode, string[] codeContext) : base(parser)
        {
            CodeContext = codeContext;

            // @TOOD: 解析得到SplitKey和SplitCount
        }

        public void Run()
        {
            // 切割变量

            return;
            Parser.ParseCodeContext(CodeContext);

            // 合并变量，并删除临时变量
        }


    }
}
