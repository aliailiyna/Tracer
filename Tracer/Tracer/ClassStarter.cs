using System.Collections.Generic;
using System.Threading;
using LibraryTracer;

namespace ConsoleApplication
{
    public class ClassStarter
    {
        private ITracer tracer;

        public static readonly int THREADS_COUNT = 3;

        public ClassStarter(ITracer argTracer)
        {
            tracer = argTracer;
        }
        public void MethodStart()
        {
            tracer.StartTrace();
            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < THREADS_COUNT; i++)
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
