using System.Collections.Generic;

namespace LibraryTracer.Tracing.TraceResult
{
    public class ThreadInformation
    {
        public long time = 0;
        public List<MethodInformation> methodsList = new List<MethodInformation>();
    }
}
