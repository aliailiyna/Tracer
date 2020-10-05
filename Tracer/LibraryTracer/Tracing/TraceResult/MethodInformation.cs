using System.Collections.Generic;

namespace LibraryTracer.Tracing.TraceResult
{
    public class MethodInformation
    {
        public string methodName;
        public string className;
        public long time;
        public List<MethodInformation> methodsList = new List<MethodInformation>();
    }
}
