using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Lab4hw.classes
{
    public class WordCounter
    {
        private String url;
        private String word;
        private int findings;
        private String duration;

        #region getters setters
        public String Url { get { return url; } set { url = value; } }
        public String Word { get { return word; } set { word = value; } }
        public int Findings { get { return findings; } set { findings = value; } }
        public String Duration { get { return duration; } set { duration = value; } }
        #endregion

        #region constructors
        public WordCounter() { }

        public WordCounter(String url)
        {
            this.url = url;
            this.findings = 0;
        }
        
        #endregion

        #region private methods
        private String GetTextFromWebsite(String url)
        {
            WebClient client = new WebClient();
            String downloadString = client.DownloadString(url);

            return downloadString;
        }

        private void GetWordsNo(String word, String text)
        {
            this.findings = new Regex(Regex.Escape(word)).Matches(text).Count;
        }

        #endregion

        public void Compute()
        {
            String text = GetTextFromWebsite(this.url);
            GetWordsNo(this.Word, text);
        }

    }
}
