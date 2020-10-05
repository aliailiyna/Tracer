using System.Collections.Generic;
using System.IO;
using LibraryTracer.Tracing.TraceResult;

namespace LibraryTracer
{
    public class XmlSerializer: ISerializer
    {
        public class XmlItem
        {
            public int id;
            public long time;
            public List<MethodInformation> methodsList = new List<MethodInformation>();
        }
        public string Serialize(TraceResult traceResult)
        {
            List<XmlItem> xmlItems = new List<XmlItem>();
            foreach (KeyValuePair<int, ThreadInformation> thread in traceResult.threadsDictionary)
            {
                XmlItem xmlItem = new XmlItem();
                xmlItem.id = thread.Key;
                xmlItem.methodsList = thread.Value.methodsList;
                xmlItem.time = thread.Value.time;
                xmlItems.Add(xmlItem);
            }

            System.Xml.Serialization.XmlSerializer xmlSerializer =
                new System.Xml.Serialization.XmlSerializer(xmlItems.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, xmlItems);
                return textWriter.ToString();
            }
        }
        public string GetName()
        {
            return "xml";
        }
    }
}
