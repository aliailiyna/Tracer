using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryTracer;
using LibraryTracer.Tracing.TraceResult;
using System.Threading;
using ConsoleApplication;

namespace ModuleTests
{
    [TestClass]
    public class UnitTestClassFirstMethodSecond
    {
        private ITracer tracer = new Tracer();

        [TestMethod]
        public void TestMethodClassFirstMethodSecondThreadId()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondMethodName()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("MethodSecond", threadInformation.methodsList[0].name, "Wrong method name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondClassName()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("ClassFirst", threadInformation.methodsList[0].className, "Wrong class name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondMethodNameNested()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("MethodFirst", threadInformation.methodsList[0].methodsList[0].name, "Wrong method name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondClassNameNested()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("ClassFirst", threadInformation.methodsList[0].methodsList[0].className, "Wrong class name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondTime()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.IsTrue(threadInformation.time >= ClassFirst.CLASS_FIRST_METHOD_SECOND_TIME_TO_SLEEP + 
                ClassFirst.CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP, "Wrong time.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondTimeNested()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.IsTrue(threadInformation.time >= ClassFirst.CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP, "Wrong time.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondThreadsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            TraceResult traceResult = tracer.GetTraceResult();
            Assert.AreEqual(1, traceResult.threadsDictionary.Count, "Wrong nubmer of threads.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondMethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(1, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList.Count, "Wrong nubmer of methods.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodSecondNestedMethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodSecond();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(1, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList[0].methodsList.Count, "Wrong nubmer of nested methods.");
        }
    }
}
