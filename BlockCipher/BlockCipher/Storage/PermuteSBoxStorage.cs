using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    public class PermuteSBoxStorage
    {
        public BaseStorage Permute { get; private set; }
        public BaseStorage SBox { get; private set; }

        public PermuteSBoxStorage(PSData[] permuteStorages, PSData[] sBoxStorages)
        {
            Permute = new BaseStorage(permuteStorages);
            SBox = new BaseStorage(sBoxStorages);
        }
    }
}
