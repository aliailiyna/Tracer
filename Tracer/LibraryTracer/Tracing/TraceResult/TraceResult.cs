using System.Collections.Concurrent;
using LibraryTracer.Tracing.TraceResult;

namespace LibraryTracer
{
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadInformation> threadsDictionary = 
            new ConcurrentDictionary<int, ThreadInformation>();
    }
}
