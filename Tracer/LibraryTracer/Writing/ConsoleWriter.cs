using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTracer
{
    public class ConsoleWriter: IWriter
    {
        public void Write(string strTraceResult)
        {
            Console.WriteLine(strTraceResult);
        }
    }
}
