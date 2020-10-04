using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTracer.Tracing.TraceResult
{
    public class MethodInformation
    {
        public string name;
        public string className;
        public long time;
        public List<MethodInformation> methodsList = new List<MethodInformation>();
    }
}
