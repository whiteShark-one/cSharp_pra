using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    public class learnAsynchronousAndParallel
    {
        // 了解异步和并行

        // 异步
        /*
            #1 async / await
                async
                    标记
                    写在方法上
                await
                    真正干活的
                    写在方法内部
                    后面必须是 Task / Task<T>（异步任务对象）
            #2 返回值规则：
                想无返回：返回 Task
                想返回数据：返回 Task<T>
                事件处理方法可以用 async void，业务代码禁止 async void
            #3 通俗理解
                同步是一条线程始终占用执行，直到代码执行完成
                异步是开始执行后，线程不卡在原地等待，直接返回（注意区分调用方法await和Main()方法await），等await任务完成，再继续执行后续代码

        */
        /*
            同步阻塞Thread.Sleep 与 异步await Task.Dealy/IO 的区别？
                #1 同步阻塞Thread.Sleep
                    - 当前线程被死死占用，不能干任何别的工作
                    - 如果是Web 服务器，大量请求 Sleep，线程池很快耗尽，服务器卡死
                #2 异步await Task.Dealy
                    - 线程归还线程池，等待期间不占用线程。不是线程在空转睡觉。
                    - await结束后，.NET从线程池再重新拿一条空闲线程继续执行
                #3 关键区别
                    - Thread.Sleep(2000)：线程不归还，霸占住线程原地睡 2 秒，线程池被占用。
                        - 线程在等，且不能归还线程池
                    - await Task.Delay(2000)：把线程还给线程池，计时由系统完成，等待阶段不消耗工作线程。
                        - 任务在等，线程被归还线程池去做别的工作（）
        */
        /*
            async异步方法，线程的去向？
                如果是Main()调用async方法，遇到await，该线程会返回Main()继续执行
                如果是在Main()中遇到await，该线程会返回线程池，后续更换线程
        */
        /*
            Main() 调用await的作用？
                控制台进程不会自动等待后台 Task。Main 方法执行完毕，整个进程直接退出，不管后台还有没有任务在跑。
                - Main() 调用异步方法，但不加await等待该方法，Main()直接向下执行，完毕后会直接退出进程，暴力摧毁后台异步未执行的剩余异步方法代码
                - Main() 调用异步方法，加await等待，等待任务完成后再向下执行，但等待期间释放线程
        */
        /*
            什么时候必须写await?
                #1 需要等待这个任务做完，再执行后续代码，必须await
                await ReadFileAsync();
                // 文件读完之后，才能解析文件内容
                ParseContent();
                #2 希望多个任务并发跑，后面再统一等，可以先不 await，保存 Task 变量，之后再 await
                // 同时启动两个任务，不等
                Task t1 = DownloadAAsync();
                Task t2 = DownloadBAsync();
                // 后续逻辑...
                // 现在再等待全部完成
                await Task.WhenAll(t1, t2);
        */

        // 同步版本，模拟耗时操作，线程空等待
        public void longWork()
        {
            Console.WriteLine("开始执行同步耗时工作");
            Thread.Sleep(3000); // 占用线程，傻傻等3秒
            Console.WriteLine("结束执行同步耗时工作");
        }
        // 异步版本 async/await + Task
        public async Task longWorkAsync()
        {
            Console.WriteLine("开始执行异步耗时工作");
            await Task.Delay(3000); // 异步等待，此处直接返回，线程释放还给线程池
            Console.WriteLine("结束执行异步耗时工作");
        }
        // 同时启动多个任务
        public async Task AAsync()
        {
            Console.WriteLine("开始执行异步任务A");
            await Task.Delay(3000);
            Console.WriteLine("结束执行异步任务A");
        }
        public async Task BAsync()
        {
            Console.WriteLine("开始执行异步任务B");
            await Task.Delay(5000);
            Console.WriteLine("结束执行异步任务B");
        }
        public async Task DelayAsync(int ms)
        {
            Console.WriteLine($"开始，线程id:{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(ms); //释放线程
            Console.WriteLine($"结束，线程id:{Thread.CurrentThread.ManagedThreadId}");
        }
        // 通过点外卖的例子，了解异步的作用
        public void orderDelivery()
        {
            Console.WriteLine("ordering delivery");
            Console.WriteLine();
        }
        // public void waitForDelivery()
        public async Task waitForDelivery()
        {
            Console.WriteLine("waiting...");
            // Thread.Sleep(3000);
            await Task.Delay(3000);
            Console.WriteLine("delivery arrived");
            Console.WriteLine();
        }
        public async Task eatDelivery()
        {
            Console.WriteLine("eating...");
            // Thread.Sleep(3000);
            await Task.Delay(3000);
            Console.WriteLine("finished eating");
            Console.WriteLine();
        }
        public async Task learCsharp()
        {
            Console.WriteLine("learning...");
            // Thread.Sleep(3000);
            await Task.Delay(10000);
            Console.WriteLine("finished learing c#");
            Console.WriteLine();
        }
    }
}