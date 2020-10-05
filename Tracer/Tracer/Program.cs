using System;
using LibraryTracer;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer();

            ClassStarter classStarter = new ClassStarter(tracer);
            classStarter.MethodStart();

            TraceResult traceResult = tracer.GetTraceResult();

            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter();

            ISerializer jsonSerializer = new JsonSerializer();
            ISerializer xmlSerializer = new XmlSerializer();

            string strJson = jsonSerializer.Serialize(traceResult);
            string strXml = xmlSerializer.Serialize(traceResult);

            consoleWriter.Write(strJson);
            consoleWriter.Write(strXml);

            fileWriter.Write(strJson);
            fileWriter.Write(strXml);

            Console.ReadLine();
        }
    }
}
