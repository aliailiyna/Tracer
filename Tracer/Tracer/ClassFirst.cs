using System;
using System.Collections.Generic;
using System.Text;
using LibraryTracer;
using System.Threading;

namespace ConsoleApplication
{
    public class ClassFirst
    {
        private ITracer tracer;
        public ClassFirst(ITracer argTracer)
        {
            tracer = argTracer;
        }

        public void MethodStart()
        {
            tracer.StartTrace();
            MethodFirst();
            MethodSecond();
            MethodFirstNested();
            MethodSecondNested();
            tracer.StopTrace();
        }
        public void MethodFirst()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        public void MethodSecond()
        {
            tracer.StartTrace();
            Thread.Sleep(150);
            MethodFirst();
            tracer.StopTrace();
        }

        public void MethodFirstNested()
        {
            tracer.StartTrace();
            MethodFirst();
            MethodSecond();
            tracer.StopTrace();
        }

        public void MethodSecondNested()
        {
            tracer.StartTrace();
            ClassSecond classSecond = new ClassSecond(tracer);
            classSecond.MethodFirst();
            classSecond.MethodSecond();
            tracer.StopTrace();
        }
    }
}
