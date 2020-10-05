using System;

namespace LibraryTracer
{
    public class ConsoleWriter: IWriter
    {
        public void Write(string strTraceResult, string name)
        {
            Console.WriteLine(name.ToUpper() + "\n");
            Console.WriteLine(strTraceResult);
        }
    }
}
