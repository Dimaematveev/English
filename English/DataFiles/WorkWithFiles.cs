using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.DataFiles
{
    public class WorkWithFiles
    {
        public List<Verb> Verbs { get; set; }
        public List<RealTranslate> RealTranslates { get; set; }

        public WorkWithFiles()
        {
            Verbs = new List<Verb>();
            Verbs = LoadFile<Verb>(@"D:\Дмитрий\source\repos\English\English\DataFiles\Verbs.txt", Encoding.Default, ';');
            RealTranslates = new List<RealTranslate>();
            RealTranslates = LoadFile<RealTranslate>(@"D:\Дмитрий\source\repos\English\English\DataFiles\RealTranslate.txt", Encoding.Default, ';');
        }
        private List<T> LoadFile<T>(string path, Encoding encoding, char separator) where T:IReadText,new()
        {
            var readTexts = new List<T>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    T tmp = new T();
                    if (line.Count(x => x.Equals(separator)) >= tmp.CountFieldText - 1) 
                    {
                        tmp.FillEverythingFromLine(line, separator);
                        readTexts.Add(tmp);
                    }
                    
                }
            }
            return readTexts;
        }
    }
}
