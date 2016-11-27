using Lab4hw.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Lab4hw
{
    public partial class MainForm : Form
    {
        private BindingSource bs;
        private int threadNo;

        public MainForm()
        {
            InitializeComponent();
            threadNo = 0;
            webTextBox.Text = "http://";

            bs = new BindingSource();
            bs.DataSource = typeof(WordCounter);

            bs.Add(new WordCounter("http://www.google.com"));
            bs.Add(new WordCounter("http://www.facebook.com"));
            bs.Add(new WordCounter("http://www.emag.ro"));
            bs.Add(new WordCounter("http://www.pcgarage.ro"));

            websitesDataGridView.DataSource = bs;
            websitesDataGridView.AutoGenerateColumns = true;
        }

        private void addWebButton_Click(object sender, EventArgs e)
        {
            String url = webTextBox.Text;
            checkAndAddUrl(url);
            websitesDataGridView.Refresh();
        }

        private void checkAndAddUrl(String url)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                int statusCode = (int) response.StatusCode;

                if (statusCode >= 100 && statusCode < 400) //Good requests
                {
                    bs.Add(new WordCounter(url));
                    return;
                }
                else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                {
                    MessageBox.Show("Url is not valid", "Error");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Url is not valid!", "Error");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            threadNo = bs.List.Count;
            String word = wordTextBox.Text;
            progressBar1.Refresh();
            progressBar1.Step = 100/threadNo;
            
            var wcs = new WordCounter[threadNo];
            var dlg = new MyDelegate(Work);

            int i;
            for (i = 0; i < threadNo; ++i)
            {
                WordCounter wc = (WordCounter)bs.List[i];
                wc.Word = word;
                wcs[i] = wc;
            }

            var asyncResults = from wc in wcs select dlg.BeginInvoke(wc, null, null);
            var results = new List<WordCounter>();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            foreach (var asyncRes in asyncResults.ToArray())
                results.Add(dlg.EndInvoke(asyncRes));

            statusLabel.Text = "Done!";
            PrintXml();
            
        }

        private void UpdateProgressBar(WordCounter wordCounter)
        {
            statusLabel.Text = "Done with " + wordCounter.Url + "!";
            progressBar1.PerformStep();
            websitesDataGridView.Refresh();
        }

        public delegate WordCounter MyDelegate(WordCounter wc);

        private WordCounter Work(WordCounter wc)
        {
            //DateTime startTime = DateTime.Now;
            Stopwatch stopWatch = Stopwatch.StartNew();
            wc.Compute();
            //DateTime endTime = DateTime.Now;
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);

            //TimeSpan ts = endTime - startTime;
            wc.Duration = elapsedTime;

            UpdateProgressBar(wc);

            return wc;
        }

        private void PrintXml()
        {
            using (XmlWriter writer = XmlWriter.Create("urls.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Items");

                foreach (WordCounter item in bs.List)
                {
                    writer.WriteStartElement("Item");

                    writer.WriteElementString("Url", item.Url);   // <-- These are new
                    writer.WriteElementString("Word", item.Word);
                    writer.WriteElementString("Findings", item.Findings.ToString());
                    writer.WriteElementString("Duration", item.Duration.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

    }
}
