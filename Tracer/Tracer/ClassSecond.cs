using System;
using System.Collections.Generic;
using System.Text;
using LibraryTracer;
using System.Threading;

namespace ConsoleApplication
{
    public class ClassSecond
    {
        private ITracer tracer;
        public ClassSecond(ITracer argTracer)
        {
            tracer = argTracer;
        }
        public void MethodFirst()
        {
            tracer.StartTrace();
            Thread.Sleep(200);
            tracer.StopTrace();
        }

        public void MethodSecond()
        {
            tracer.StartTrace();
            Thread.Sleep(250);
            MethodFirst();
            tracer.StopTrace();
        }
    }
}
