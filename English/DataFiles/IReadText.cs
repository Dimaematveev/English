using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.DataFiles
{
    public interface IReadText
    {
        void FillEverythingFromLine(string line,char separator);
        string LineForWriteFile(char separator);
        int CountFieldText { get; }
    }
}
