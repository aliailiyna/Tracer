using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryTracer;
using LibraryTracer.Tracing.TraceResult;
using System.Threading;
using ConsoleApplication;

namespace ModuleTests
{
    [TestClass]
    public class UnitTestClassStarter
    {
        private ITracer tracer = new Tracer();

        [TestMethod]
        public void TestMethodThreadsNumber()
        {
            ClassStarter classStarter = new ClassStarter(tracer);
            classStarter.MethodStart();

            TraceResult traceResult = tracer.GetTraceResult();
            Assert.AreEqual(ClassStarter.THREADS_COUNT + 1, traceResult.threadsDictionary.Count, "Wrong nubmer of threads.");
        }
    }
}
