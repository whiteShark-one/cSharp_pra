using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AsyncMultiThread
{
    public class MultiThread
    {
        /*
            1. 长驻消费工作线程 → Thread
            2. 普通业务异步、IO 任务 → Task.Run + await
            3. CPU 密集批量循环 → Parallel
            4. 多线程共享数据：优先用 并发集合；复杂临界区使用锁机制。
        */
        /*
            现代异步编程请使用 Task + async/await，这并非“多线程”，而是基于线程池的高效异步模型。
            如果只是想执行耗时操作而不阻塞 UI，请直接用 Task.Run 配合 await，这已经是 C# 的官方最佳实践。
        */

        /// <summary>
        /// 1、使用 Thread 类 （原生操作系统线程）
        /// </summary>
        /*
            Thread类是最基本的多线程实现方式。通过ThreadStart或ParameterizedThreadStart委托，可以创建一个Thread对象并启动一个新线程来执行指定的任务。
            可以使用Start()方法来启动线程，使用Join()方法来等待线程完成，或者使用Abort()方法来终止线程。此外，还可以设置线程的优先级、名称和是否为后台线程等属性。
        */
        /* 常用类和方法
            - `Start()`：启动线程
            - `Join()`：等待线程执行完毕，可设置超时。Join() 的作用是让调用它的线程（通常是主线程/老板）暂停执行，直到目标线程（子线程/员工）执行完毕，才继续往下走。
            - `Sleep()`：让当前线程休眠阻塞
            - `IsBackground`：设置是否后台线程，程序退出后台线程直接结束。IsBackground 决定了线程是前台线程（Foreground）还是后台线程（Background）。它直接影响整个进程（公司）的生命周期。
            - `IsAlive`：判断线程是否还在运行
            - `Priority`：设置线程优先级
            > 适用：长驻循环工作线程；开销大，手动管理生命周期。
        */
        /*
            Thread中Join()和IsBackground搭配的4种情况（假设子线程需要运行 5 秒，主线程代码 1 秒 run 完）
                1、IsBackground = false，不Join()；主线程 1 秒后结束，但进程不退出。等子线程 5 秒跑完后，进程才退出。
                2、IsBackground = true，不Join()；主线程 1 秒后结束，进程立刻退出。子线程被瞬间强杀，只跑了 1 秒。
                3、IsBackground = false，Join()；主线程被阻塞 5 秒。5 秒后子线程结束，主线程继续跑，然后进程退出。
                4、IsBackground = true，Join()；主线程被阻塞 5 秒（强行等临时工干完）。5 秒后子线程结束，主线程继续跑，然后进程退出。
        */
        public static void ThreadMethod()
        {
            var newThread = new Thread(WorkerMethod);
            newThread.Start();

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"ThreadMethod 主线程开始工作：{i}");
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 2、使用 ThreadPool 类
        /// </summary>
        /*
            ThreadPool类提供了一个线程池，可以用来执行短暂的任务。线程池管理着一组线程，当有新任务时，会尝试重用已存在的线程，从而减少创建和销毁线程的开销。
            使用ThreadPool.QueueUserWorkItem方法可以将任务排入队列等待执行。
        */
        /* 常用类和方法
            - `QueueUserWorkItem()`：把任务排入线程池执行
            - `SetMaxThreads()`：设置线程池最大线程数
            - `GetAvailableThreads()`：获取可用线程数量
            > 适用：大量短小任务，复用线程；不适合长时间阻塞任务，无法控制单个线程。
        */
        public static void ThreadPoolMethod()
        {
            ThreadPool.QueueUserWorkItem(o => WorkerMethod());

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"ThreadPoolMethod 主线程开始工作：{i}");
                Thread.Sleep(100);
            }
        }
        /*
            ThreadPool和Task底层原理和写法区别？
                虽然理解 ThreadPool 的底层原理很重要，但在现代 C# 开发中，我们几乎不再直接调用 ThreadPool.QueueUserWorkItem。
                微软推出了更高级的 Task (TPL - Task Parallel Library)，它底层默认就是基于线程池实现的，但提供了更好的返回值、异常处理、链式调用和 async/await 支持。
            注意两者区别和写法
        */

        /// <summary>
        /// 3、使用 Task 类 （现代首选，基于线程池，支持 await）
        /// </summary>
        /*
            Task类提供了一个基于任务的多线程模型，它是Thread和ThreadPool的高级抽象。Task可以获取线程的返回值，定义连续的任务，以及创建任务层次结构。
            Task通常使用线程池中的线程，但也可以通过TaskCreationOptions.LongRunning属性来指示创建一个新的线程。
        */
        /*
            表示一个异步操作：它不代表线程本身，而是代表一个未来的结果（Promise）。
            统一异步模型：无论是 CPU 密集型计算，还是 IO 密集型操作（网络、磁盘），都用 Task 来表示。
            支持组合与编排：可以轻松实现并行、串行、超时、取消、异常聚合等复杂逻辑。
            async/await 的基石：await 后面跟的就是 Task。
        */
        /* 常用类和方法
            - `Task.Run()`：在线程池启动任务
            - `Factory.StartNew()`：高级创建任务，可配置选项
            - `WhenAll()`：等待全部任务完成；`WhenAny()`：等待任意一个任务完成
            - `Task.Delay()`：异步延时，不阻塞线程
            - `TaskCompletionSource`：手动控制 Task 完成状态，封装异步操作
            > 适用：绝大多数业务，支持取消令牌、返回值、async/await。
        */
        public static void TaskMethod()
        {
            Task.Run(() => WorkerMethod());

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"TaskMethod 主线程开始工作：{i}");
                Task.Delay(100).Wait();
            }
        }

        public static async Task<string> DownloadAsync(string name, int delay)
        {
            Console.WriteLine($"{name} 开始下载...");
            await Task.Delay(delay); // 模拟 IO 等待，不占用线程
            Console.WriteLine($"{name} 下载完成！");
            return $"{name}的数据";
        }

        /// <summary>
        /// 4、使用 Parallel 类
        /// </summary>
        /*
            Parallel类提供了数据并行和任务并行的方法。Parallel.For和Parallel.ForEach可以用于数据并行，即对数据集合中的每个元素并行执行相同的操作。Parallel.Invoke可以用于任务并行，即同时执行多个不同的方法。
        */
        /*
            - `Parallel.For()`：并行 for 循环
            - `Parallel.ForEach()`：并行遍历集合
            - `Parallel.Invoke()`：并行执行多个方法
            - `ParallelOptions`：配置最大并发数、取消令牌
            > 适用：CPU 密集批量计算。
        */
        public static void ParallelMethod()
        {
            Parallel.Invoke(WorkerMethod, WorkerMethodOther1, WorkerMethodOther2);
        }

        /*
        ## 5. 同步锁类（解决多线程资源竞争）

        - `lock`：语法糖，简易互斥锁，保护共享代码块
        - `Monitor`：底层锁实现，支持等待、脉冲
        - `Mutex`：跨进程也可用的互斥锁
        - `Semaphore`：信号量，控制允许同时执行的线程数量
        - `ReaderWriterLock`：读写锁，读多写少场景优化性能

        ## 6. 线程安全并发集合 `System.Collections.Concurrent`

        - `ConcurrentQueue`：线程安全队列
        - `ConcurrentStack`：线程安全栈
        - `ConcurrentDictionary`：线程安全字典
        - `ConcurrentBag`：无序线程安全集合

        > 多线程读写无需手动 lock，内部已经做线程安全处理。
        */

        private static void WorkerMethod()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"WorkerMethod 辅助线程开始工作：{i}");
                Thread.Sleep(100);
            }
        }



        private static void WorkerMethodOther1()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"WorkerMethodOther1 辅助线程开始工作：{i}");
                Thread.Sleep(100);
            }
        }

        private static void WorkerMethodOther2()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"WorkerMethodOther2 辅助线程开始工作：{i}");
                Thread.Sleep(100);
            }
        }

    }
}