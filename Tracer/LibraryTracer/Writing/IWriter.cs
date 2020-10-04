using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTracer
{
    public interface IWriter
    {
        void Write(string strTraceResult);
    }
}
