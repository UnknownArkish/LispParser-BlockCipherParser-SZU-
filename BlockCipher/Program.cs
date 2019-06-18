using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace BlockCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //BitArray test = new BitArray(new bool[] { true, false, false });
            //Console.WriteLine(BlockCipherUtil.BitArrayToString(test));

            //string temp = "state(88)";
            //string length = Regex.Match(temp, "((\\d+))").Value;
            //string key = Regex.Match(temp, "(\\w+)").Value;

            //test = new BitArray(8);
            //Console.WriteLine(BlockCipherUtil.BitArrayToString(test));

            // 输入置换和S盒
            string psCount = Console.ReadLine();

            string[] psCounts = psCount.Split(' ');
            PSData[] permutes = InputPSData(int.Parse(psCounts[0]));
            PSData[] sBoxs = InputPSData(int.Parse(psCounts[1]));

            // 输入未经处理的上下文
            string[] rawContext = InputRawContext();


            // 创建加密算法解析器
            BlockCipherParser parser = new BlockCipherParser(permutes, sBoxs, rawContext);

            // 输入state和key并进行加密
            int runCount = int.Parse(Console.ReadLine());
            while (runCount-- > 0)
            {
                string state = Console.ReadLine();
                string key = Console.ReadLine();

                parser.Run(state, key);

                Console.WriteLine( "state::" + parser.GetState());
                Console.WriteLine( "key::" +  parser.GetKey());
            }

            Console.WriteLine("Well Done!");
            Console.ReadKey();
        }

        /// <summary>
        /// 输入并返回置换盒
        /// </summary>
        /// <returns></returns>
        static PSData[] InputPSData(int count)
        {
            List<PSData> result = new List<PSData>();

            int inpuLength, outputLength;
            for (int i = 0; i < count; i++)
            {
                string length = Console.ReadLine();
                string data = Console.ReadLine();

                string[] lengths = length.Split(' ');
                inpuLength = int.Parse(lengths[0]);
                outputLength = int.Parse(lengths[1]);

                string[] datas = data.Split(' ');
                int[] temp = new int[datas.Length];
                for (int j = 0; j < datas.Length; j++)
                {
                    temp[j] = int.Parse(datas[j]);
                }

                PSData pSData = new PSData()
                {
                    InputLength = inpuLength,
                    OutputLength = outputLength,
                    Data = temp
                };
                result.Add(pSData);
            }

            return result.ToArray();
        }

        static string[] InputRawContext()
        {
            List<string> result = new List<string>();
            string temp;
            do
            {
                temp = Console.ReadLine();
                result.Add(temp);
                if( "END".Equals(temp))
                {
                    break;
                }
            } while (true);
            return result.ToArray();
        }

    }
}
