using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 处理Loop循环的Handler
    /// 需要提供三个参数，分别是循环变量、初始值和结束值
    /// </summary>
    public class LoopHandler : BaseHandler
    {
        public string LoopKey { get; private set; }                     // 循环变量名
        public int LoopFrom { get; private set; }                       // 循环起始值
        public int LoopTo { get; private set; }                         // 循环终止值
        public string[] CodeContext { get; private set; }               // 此LoopHandler管理的代码块
        
        public LoopHandler(BlockCipherParser parser,
            string loopCode, string[] codeContext ) : base(parser)
        {
            loopCode = loopCode.Trim();
            string[] loopDetails = loopCode.Split(' ');

            LoopKey = loopDetails[1];
            LoopFrom = int.Parse(loopDetails[2]);
            LoopTo = int.Parse(loopDetails[3]);

            CodeContext = codeContext;
        }


        public void Run()
        {
            for (int i = LoopFrom; i <= LoopTo; i++)
            {
                // @TODO: 注册LoopKey->i到RuntimeStorage中
                Parser.LoopVariableStorage.Push(LoopKey, i);

                // 调用Parser解析代码上下文的代码
                Parser.ParseCodeContext(CodeContext);

                // @TODO:取消注册LoopKey
                Parser.LoopVariableStorage.Pop(LoopKey);
            }
        }
    }
}
