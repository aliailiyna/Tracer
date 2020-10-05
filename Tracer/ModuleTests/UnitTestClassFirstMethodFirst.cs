using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryTracer;
using LibraryTracer.Tracing.TraceResult;
using System.Threading;
using ConsoleApplication;

namespace ModuleTests
{
    [TestClass]
    public class UnitTestClassFirstMethodFirst
    {
        private ITracer tracer = new Tracer();

        [TestMethod]
        public void TestMethodClassFirstMethodFirstThreadId()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirst();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstMethodName()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirst();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("MethodFirst", threadInformation.methodsList[0].name, "Wrong method name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstClassName()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirst();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("ClassFirst", threadInformation.methodsList[0].className, "Wrong class name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstTime()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirst();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.IsTrue(threadInformation.time >= ClassFirst.CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP, "Wrong time.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstThreadsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirst();

            TraceResult traceResult = tracer.GetTraceResult();
            Assert.AreEqual(1, traceResult.threadsDictionary.Count, "Wrong nubmer of threads.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstMethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirst();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(1, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList.Count, "Wrong nubmer of methods.");
        }
    }
}
