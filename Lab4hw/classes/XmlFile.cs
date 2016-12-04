using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab4hw.classes
{
    public class XmlFile
    {
        private static String fileName = @"urls.xml";
        private static String fileName2 = @"urls2.xml";
        private Object obj = (Object)fileName;
        private Object obj2 = (Object)fileName2;

        #region getters setters
        public Object Obj { get; set; }
        public String FileName { get; }
        #endregion

        public XmlFile(List<WordCounter> wcList)
        {
            File.WriteAllText(fileName, string.Empty);

            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("items");

                foreach (WordCounter item in wcList)
                {
                    writer.WriteStartElement("item");

                    writer.WriteElementString("url", item.Url);   // <-- These are new
                    writer.WriteElementString("word", item.Word);
                    writer.WriteElementString("findings", item.Findings.ToString());
                    writer.WriteElementString("duration", item.Duration.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void UpdateXml(List<WordCounter> wcList)
        {
            for (int i = 0; i < wcList.Count; ++i)
            {
                WriteXml(wcList[i]);
            }
        }

        public void WriteXml(WordCounter wc)
        {
            
            try
            {
                String fileName = (String)obj;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                XmlNodeList itemNodes = xmlDoc.SelectNodes("//items/item");
                foreach (XmlNode itemNode in itemNodes)
                {
                    if (itemNode.ChildNodes[0].InnerText == wc.Url)
                    {
                        itemNode.ChildNodes[1].InnerText = wc.Word;
                        itemNode.ChildNodes[2].InnerText = (wc.Findings).ToString();
                        itemNode.ChildNodes[3].InnerText = (wc.Duration).ToString();
                    }
                }
                xmlDoc.Save(fileName);
            }
            finally
            {
                System.Threading.Monitor.Exit(obj);
            }

        }

        public void SerializeXml(WordCounter wc)
        {
            System.Threading.Monitor.Enter(obj2);
            try
            {
                String filename2 = (String)obj2;
                XmlSerializer serializer = new XmlSerializer(typeof(WordCounter));
                TextWriter writer = new StreamWriter(fileName);
                serializer.Serialize(writer, wc);
            }
            finally
            {
                System.Threading.Monitor.Exit(obj2);
            }
        }
    }
}
