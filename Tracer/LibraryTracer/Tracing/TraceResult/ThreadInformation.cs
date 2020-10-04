using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTracer.Tracing.TraceResult
{
    public class ThreadInformation
    {
        public long time = 0;
        public List<MethodInformation> methodsList = new List<MethodInformation>();
    }
}
