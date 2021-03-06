﻿using Newtonsoft.Json;

namespace LibraryTracer
{
    public class JsonSerializer: ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            return JsonConvert.SerializeObject(traceResult, Formatting.Indented);
        }
        public string GetName()
        {
            return "json";
        }
    }
}
