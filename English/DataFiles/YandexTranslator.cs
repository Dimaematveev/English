using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Translator
{
    public class YandexTranslator
    {
        public string Translate(string s, string lang)
        {
            if (s.Length > 0)
            {
                WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                    + "key=trnsl.1.1.20200510T142518Z.dde8a564e83c2a9a.d71841dc6e5bb2075ef1e6e46d39025e34ac2c8f"
                    + "&text=" + s
                    + "&lang=" + lang);

                WebResponse response = request.GetResponse();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;

                    if ((line = stream.ReadLine()) != null)
                    {
                        Translation translation = JsonConvert.DeserializeObject<Translation>(line);

                        s = "";

                        foreach (string str in translation.Texts)
                        {
                            s += str;
                        }
                    }
                }

                return s;
            }
            else
                return "";
        }
    }

    public class Translation
    {
        public string Code { get; set; }
        public string Lang { get; set; }
        public string[] Texts { get; set; }
    }
}