using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using LibraryTracer;
using LibraryTracer.Tracing.TraceResult;

namespace ModuleTests
{
    [TestClass]
    public class UnitTestSelf
    {
        private ITracer tracer = new Tracer();

        [TestMethod]
        public void TestMethodSelfThreadId()
        {
            tracer.StartTrace();
            tracer.StopTrace();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, 
                out threadInformation), "No such thread.");
        }

        [TestMethod]
        public void TestMethodSelfMethodName()
        {
            tracer.StartTrace();
            tracer.StopTrace();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, 
                out threadInformation), "No such thread.");
            Assert.AreEqual("TestMethodSelfMethodName", threadInformation.methodsList[0].methodName, "Wrong method name.");
        }

        [TestMethod]
        public void TestMethodSelfClassName()
        {
            tracer.StartTrace();
            tracer.StopTrace();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, 
                out threadInformation), "No such thread.");
            Assert.AreEqual("UnitTestSelf", threadInformation.methodsList[0].className, "Wrong class name.");
        }

        [TestMethod]
        public void TestMethodSelfThreadsCount()
        {
            tracer.StartTrace();
            tracer.StopTrace();

            TraceResult traceResult = tracer.GetTraceResult();
            Assert.AreEqual(1, traceResult.threadsDictionary.Count, "Wrong nubmer of threads.");
        }

        [TestMethod]
        public void TestMethodSelfMethodssCount()
        {
            tracer.StartTrace();
            tracer.StopTrace();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(1, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList.Count, "Wrong nubmer of methods.");
        }
    }
}