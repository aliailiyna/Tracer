﻿namespace LibraryTracer
{
    public interface ISerializer
    {
        string Serialize(TraceResult traceResult);
        string GetName();
    }
}
