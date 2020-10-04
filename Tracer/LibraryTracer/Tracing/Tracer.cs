using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTracer
{
    public class Tracer: ITracer
    {
        private TraceResult traceResult = new TraceResult();
        // вызывается в начале замеряемого метода
        public void StartTrace()
        {

        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {

        }

        // получить результаты измерений  
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }
    }
}
