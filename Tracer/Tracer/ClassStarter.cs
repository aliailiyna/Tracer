using System;
using System.Collections.Generic;
using System.Text;
using LibraryTracer;
using System.Threading;
using System.IO;

namespace ConsoleApplication
{
    public class ClassStarter
    {
        private ITracer tracer;

        public ClassStarter(ITracer argTracer)
        {
            tracer = argTracer;
        }
        public void MethodStart()
        {
            tracer.StartTrace();
            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < 2; i++)
            {
                ClassFirst firstClass = new ClassFirst(tracer);
                Thread thread = new Thread(firstClass.MethodStart);
                threadList.Add(thread);
                thread.Start();
            }
            foreach (Thread thread in threadList)
            {
                thread.Join();
            }
            tracer.StopTrace();
        }
    }
}
