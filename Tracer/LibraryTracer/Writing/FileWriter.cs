using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibraryTracer
{
    public class FileWriter: IWriter
    {
        public void Write(string strTraceResult, string name)
        {
            string path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 4; i++)
            {
                path = Directory.GetParent(path).FullName;
            }

            using (StreamWriter sw = new StreamWriter(path + "/result." + name, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(strTraceResult);
            }
        }
    }
}
