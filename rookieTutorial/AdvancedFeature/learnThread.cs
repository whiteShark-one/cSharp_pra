using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    public class learnThread
    {

        #region new Thread()新建并管理一个线程
        // 创建一个新线程Start()
        /*
            1. 主线程调用 `createNewThread()`
            2. `new Thread(...)` 创建线程对象，**还没运行**
            3. `childThread.Start()`：告诉操作系统调度子线程，**主线程立刻继续执行，不会等子线程跑完**
            4. 主线程打印空行，`createNewThread()` 方法执行完毕
            5. 此时主线程继续跑自己后面代码；
            6. 同时子线程开始执行 `CallToChildThread`，子线程执行 `Thread.Sleep(5000)`，**子线程自己休眠 5 秒**
            7. 重点：**默认新建的 Thread 是前台线程（IsBackground=false）**
                > 控制台程序：只要还有任意**前台线程在运行，进程就不能退出**。
                > 哪怕主线程已经跑完 Main 函数，程序也会挂住，等待前台子线程执行完毕。
        */
        public void createNewThread()
        {
            Console.WriteLine();
            // 写法1：将ThreadStart连带方法传入Thread
            // ThreadStart chidref = new ThreadStart(CallToChildThread);   // 委托，用于传递给Thread启用方法，可忽略
            // Console.WriteLine("In Main: Creating the Child thread");
            // Thread childThread = new Thread(chidref);
            // childThread.Start();
            // 写法2：简写，编译器自动推断委托（最常见）
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(CallToChildThread);
            childThread.Start();
            // // 主线程继续输出，证明主线程没有Sleep阻塞
            // for (int i = 0; i < 3; i++)
            // {
            //     Console.WriteLine($"主线程还在运行 i={i}");
            //     Thread.Sleep(800);
            // }
            // 暂停主线程一段时间
            Thread.Sleep(2000);
            // childThread.Abort();
            Console.WriteLine();
        }

        // 管理线程
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");
            // 线程暂停5000毫秒
            int sleepfor = 5000;
            Console.WriteLine("Child Thread Paused for {0} seconds",
                              sleepfor / 1000);
            Thread.Sleep(sleepfor);
            Console.WriteLine("Child thread resumes");
        }
        // 销毁线程
        /*
            Abort() 方法用于销毁线程。
            通过抛出 threadabortexception 在运行时中止线程。
            这个异常不能被捕获，如果有 finally 块，控制会被送至 finally 块。
        */
        // public static void CallToChildThread()
        // {
        //     try
        //     {

        //         Console.WriteLine("Child thread starts");
        //         // 计数到 10
        //         for (int counter = 0; counter <= 10; counter++)
        //         {
        //             Thread.Sleep(500);
        //             Console.WriteLine(counter);
        //         }
        //         Console.WriteLine("Child Thread Completed");
        //     }
        //     catch (ThreadAbortException e)
        //     {
        //         Console.WriteLine("Thread Abort Exception");
        //     }
        //     finally
        //     {
        //         Console.WriteLine("Couldn't catch the Thread Exception");
        //     }
        // }
        #endregion

        #region  Task + CancellationTokenSource
        public async Task learnCancellationTokenSource(CancellationToken token)
        {
            for (int i = 0; i < 100; i++)
                {
                    // 检测是否请求取消，收到取消直接抛异常
                    token.ThrowIfCancellationRequested();

                    Console.WriteLine($"working:{i}");
                    // 异步等待200ms，可以被token打断
                    await Task.Delay(200,token);
                }
        }
        #endregion
    }
}