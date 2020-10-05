﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using LibraryTracer;
using LibraryTracer.Tracing.TraceResult;
using ConsoleApplication;

namespace ModuleTests
{
    [TestClass]
    public class UnitTestClassFirstMethodFirstNested
    {
        private ITracer tracer = new Tracer();

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNestedThreadId()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNestedMethodName()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("MethodFirstNested", threadInformation.methodsList[0].methodName, "Wrong method name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNestedClassName()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.AreEqual("ClassFirst", threadInformation.methodsList[0].className, "Wrong class name.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNestedTime()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId, out threadInformation), "No such thread.");
            Assert.IsTrue(threadInformation.time >= ClassFirst.CLASS_FIRST_METHOD_SECOND_TIME_TO_SLEEP +
                ClassFirst.CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP +
                ClassFirst.CLASS_FIRST_METHOD_FIRST_TIME_TO_SLEEP, "Wrong time.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNestedThreadsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            TraceResult traceResult = tracer.GetTraceResult();
            Assert.AreEqual(1, traceResult.threadsDictionary.Count, "Wrong nubmer of threads.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNestedMethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(1, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList.Count, "Wrong nubmer of methods.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNested2MethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(2, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList[0].methodsList.Count, "Wrong nubmer of methods.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNested21MethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(0, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList[0].methodsList[0].methodsList.Count, "Wrong nubmer of methods.");
        }

        [TestMethod]
        public void TestMethodClassFirstMethodFirstNested22MethodsCount()
        {
            ClassFirst classFirst = new ClassFirst(tracer);
            classFirst.MethodFirstNested();

            TraceResult traceResult = tracer.GetTraceResult();
            ThreadInformation threadInformation;
            Assert.IsTrue(tracer.GetTraceResult().threadsDictionary.TryGetValue(Thread.CurrentThread.ManagedThreadId,
                out threadInformation), "No such thread.");
            Assert.AreEqual(1, traceResult.threadsDictionary[Thread.CurrentThread.ManagedThreadId].methodsList[0].methodsList[1].methodsList.Count, "Wrong nubmer of methods.");
        }
    }
}
