using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTracer
{
    public interface ISerializer
    {
        string Serialize(TraceResult traceResult);
        string GetName();
    }
}
