using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Diagnostics;
using LibraryTracer.Tracing.TraceResult;
using System.Reflection;

namespace LibraryTracer
{
    class StackItem
    {
        public long startTime;
        public MethodInformation methodInformation;
    }
    public class Tracer: ITracer
    {
        private ConcurrentDictionary<int, Stack<StackItem>> stackItems =
            new ConcurrentDictionary<int, Stack<StackItem>>();

        private TraceResult traceResult = new TraceResult();

        // вызывается в начале замеряемого метода
        public void StartTrace()
        {
            // получение идентификатора выполняемого потока
            int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

            // нахождение информации о выполняемом потоке в словарь потоков и в случае необходимости - добавление
            traceResult.threadsDictionary.GetOrAdd(threadId, new ThreadInformation());

            // нахождение информации о выполняемом потоке и в случае необходимости - добавление её в словарь стеков
            Stack<StackItem> stack = stackItems.GetOrAdd(threadId, new Stack<StackItem>());

            // создание элемента стека, стекового фрейма и получение информации о методе
            StackItem stackItem = new StackItem();
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();

            // создание информации о методе
            stackItem.methodInformation = new MethodInformation();
            stackItem.methodInformation.name = methodBase.Name;
            stackItem.methodInformation.className = methodBase.DeclaringType.Name;

            // если стек не пуст
            if (stack.Count != 0)
            {
                // получение информацию о родителе метода
                MethodInformation parent = stack.Peek().methodInformation;
                // добавление информацию о методе в список методов родителя
                parent.methodsList.Add(stackItem.methodInformation);
            }
            // если стек пуст
            else
            {
                // добавление информацию о методе в список методов потока
                ThreadInformation threadInfo;
                if (traceResult.threadsDictionary.TryGetValue(threadId, out threadInfo))
                {
                    threadInfo.methodsList.Add(stackItem.methodInformation);
                }
            }
            // добавление на стек элемента стека
            stack.Push(stackItem);
            // начало измерения времени
            stackItem.startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {
            // получение идентификатора выполняемого потока
            int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            // получение стека из списка потоков
            Stack<StackItem> stack;
            stackItems.TryGetValue(threadId, out stack);

            // удаление элемента со стека
            StackItem stackItem = stack.Pop();
            // окончание измерения времени
            long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            // нахождение времени выполнения метода
            stackItem.methodInformation.time = endTime - stackItem.startTime;

            // добавление информации о методе в список методов потока
            ThreadInformation threadInfo;
            if (traceResult.threadsDictionary.TryGetValue(threadId, out threadInfo))
            {
                threadInfo.time += stackItem.methodInformation.time;
            }
        }

        // получить результаты измерений  
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }
    }
}
