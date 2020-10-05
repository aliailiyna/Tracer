using System.Threading;
using LibraryTracer;

namespace ConsoleApplication
{
    public class ClassSecond
    {
        private ITracer tracer;

        public static readonly int CLASS_SECOND_METHOD_FIRST_TIME_TO_SLEEP = 200;
        public static readonly int CLASS_SECOND_METHOD_SECOND_TIME_TO_SLEEP = 250;
        public ClassSecond(ITracer argTracer)
        {
            tracer = argTracer;
        }
        public void MethodFirst()
        {
            tracer.StartTrace();
            Thread.Sleep(CLASS_SECOND_METHOD_FIRST_TIME_TO_SLEEP);
            tracer.StopTrace();
        }

        public void MethodSecond()
        {
            tracer.StartTrace();
            Thread.Sleep(CLASS_SECOND_METHOD_SECOND_TIME_TO_SLEEP);
            MethodFirst();
            tracer.StopTrace();
        }
    }
}
