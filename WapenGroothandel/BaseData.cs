using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WapenGroothandel
{
    public abstract class BaseData<T> where T : BaseData<T>, new()
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        protected abstract void WriteClassSpecificXml(XmlWriter writer);
        protected abstract void ReadClassSpecificXml(XmlReader reader);
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            if (reader.EOF) return;
            ReadClassSpecificXml(reader); //dit zodat we mogelijks nog een omvorming kunnen maken van het wegschrijven van data en het mogelijks inlezen
        }
        public void WriteXml(XmlWriter writer)
        {
            WriteClassSpecificXml(writer);
        }

        public void SchrijfDataNaar(string xmlPath, bool createUniqueFile = false)
        {
            if (createUniqueFile)
            {
                //we passen de xmlFilenaam aan aan
                if (xmlPath.Contains('.'))
                {
                    int firstPointIndex = xmlPath.IndexOf('.');
                    xmlPath = xmlPath.Substring(0, firstPointIndex);
                }

                int counter = 1;
                string newPath = xmlPath;
                while (File.Exists(newPath))
                {
                    newPath = $"{xmlPath}_{counter}";
                }

                xmlPath = newPath;

            }


            DataManager.Instance.SchrijfXML(this as T, xmlPath);

        }

        public virtual void Clear()
        {
        }
    }
}
