using System.Threading;
using LibraryTracer;

namespace ConsoleApplication
{
    public class ClassFirst
    {
        private ITracer tracer;

        public static readonly int CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP = 100;
        public static readonly int CLASS_FIRST_METHOD_SECOND_TIME_TO_SLEEP = 150;
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
            Thread.Sleep(CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP);
            tracer.StopTrace();
        }

        public void MethodSecond()
        {
            tracer.StartTrace();
            Thread.Sleep(CLASS_FIRST_METHOD_SECOND_TIME_TO_SLEEP);
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
