using Lab4hw.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Lab4hw
{
    public partial class MainForm : Form
    {
        private List<WordCounter> wcList = new List<WordCounter>();
        private BindingSource bs = new BindingSource();
        private int threadNo = 0;
        private XmlFile xmlFile;

        public MainForm()
        {
            InitializeComponent();
            InitBindingSource();
            webTextBox.Text = "http://";
            
            CreateWordCounterList();
            xmlFile = new XmlFile(wcList);
        }

        private void InitBindingSource()
        {
            bs.DataSource = typeof(WordCounter);
            bs.Add(new WordCounter("http://www.google.com"));
            bs.Add(new WordCounter("http://www.facebook.com"));
            bs.Add(new WordCounter("http://www.emag.ro"));
            bs.Add(new WordCounter("http://www.pcgarage.ro"));

            websitesDataGridView.DataSource = bs;
            websitesDataGridView.AutoGenerateColumns = true;
        }

        #region add website
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
                    WordCounter wc = new WordCounter(url);
                    bs.Add(wc);
                    wcList.Add(wc);
                    return;
                }
                else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                {
                    MessageBox.Show("Server error!", "Error");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Url is not valid!", "Error");
            }
        }
        #endregion

        #region start computations
        private void startButton_Click(object sender, EventArgs e)
        {
            String word = wordTextBox.Text;
            threadNo = bs.List.Count;

            SetupProgressBar();
            
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
            foreach (var asyncRes in asyncResults.ToArray())
                results.Add(dlg.EndInvoke(asyncRes));


            WriteProgressBar("Done!");
            xmlFile.UpdateXml(wcList);

        }

        private void CreateWordCounterList()
        {
            for (int i = 0; i < bs.List.Count; ++i)
            {
                WordCounter wc = (WordCounter)bs.List[i];
                this.wcList.Add(wc);
            }
        }

        private void SetupProgressBar()
        {
            progressBar1.Refresh();
            progressBar1.Step = 100 / threadNo;
        }

        private void WriteProgressBar(String text)
        {
            progressBar1.CreateGraphics().DrawString(text, new Font("Arial",
            (float)8), Brushes.Black, new PointF(progressBar1.Width / 2 - 20, progressBar1.Height / 2 - 7));
        }

        private void UpdateProgressBar(WordCounter wordCounter)
        {
            progressBar1.PerformStep();
            WriteProgressBar("Done with " + wordCounter.Url + "!");
            websitesDataGridView.Refresh();
            

        }

        public delegate WordCounter MyDelegate(WordCounter wc);

        private WordCounter Work(WordCounter wc)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            wc.Compute(xmlFile);
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            wc.Duration = elapsedTime;

            //xmlFile.SerializeXml(wc);
            UpdateProgressBar(wc);
            return wc;
        }
        #endregion


    }
}
