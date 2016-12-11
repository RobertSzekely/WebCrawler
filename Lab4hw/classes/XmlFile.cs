using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab4hw.classes
{
    public class XmlFile
    {
        private static String fileName = @"urls2.xml";
        private ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();


        #region getters setters
        public Object Obj { get; set; }
        public String FileName { get; }
        #endregion

        public XmlFile() { }

        public void SerializeObjectXml(WordCounter wc)
        {

            if (File.Exists(fileName))
            {

                lock_.EnterWriteLock();
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(WordCounter),
                        new XmlRootAttribute("WordCounterList"));
                    TextWriter writer = new StreamWriter(fileName);
                    serializer.Serialize(writer, wc);
                    writer.Close();
                }
                finally
                {
                    lock_.ExitWriteLock();
                }
            }

        }

        public void SerializeListXml(List<WordCounter> wcList)
        {

            if (File.Exists(fileName))
            {
                lock_.EnterWriteLock();
                try
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(List<WordCounter>),
                        new XmlRootAttribute("WordCounterList"));
                    TextWriter writer = new StreamWriter(fileName);
                    serializer.Serialize(writer, wcList);
                    writer.Close();
                }
                finally
                {
                    lock_.ExitWriteLock();
                }
            }
        }

        public List<WordCounter> DeserializeListXml()
        {
            List<WordCounter> list = new List<WordCounter>();

            if (File.Exists(fileName))
            {
                lock_.EnterReadLock();
                using (var reader = new StreamReader(fileName))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<WordCounter>),
                        new XmlRootAttribute("WordCounterList"));
                    list = (List<WordCounter>)deserializer.Deserialize(reader);
                }
                lock_.ExitReadLock();
                return list;
            }

            return null;
        }

    }
};
