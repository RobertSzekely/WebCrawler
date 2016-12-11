using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace Lab4hw.classes
{
    public class WordCounter
    {
        #region public members
        public String url;
        public String word;
        public int findings;
        public String duration;
        #endregion

        #region getters setters
        public String Url { get { return this.url; } set { url = value; } }
        public String Word { get { return this.word; } set { word = value; } }
        public int Findings { get { return this.findings; } set { findings = value; } }
        public String Duration { get { return this.duration; } set { duration = value; } }
        #endregion

        #region constructors
        public WordCounter() { }

        public WordCounter(String url)
        {
            this.url = url;
            this.word = "";
            this.findings = 0;
            this.duration = "";
        }
        #endregion

        private void GetWordsNo(String word, String text)
        {
            this.findings += new Regex(Regex.Escape(word)).Matches(text).Count;
        }

        public void Compute(XmlFile xmlFile)
        {
            WebClient client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    GetWordsNo(this.Word, line);
                }
            }
        }

    }
}
