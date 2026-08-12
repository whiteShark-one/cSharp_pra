using learnAoiVision.saveImagePro;

namespace learnAoiVision;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        #region 异步多线程存储图片模块任务
        // #1 程序入口
        Console.WriteLine("===== 异步存图Demo开始 =====");
        // #2 实例化存图管理器，队列最大容量20
        var imageSaver = new AsyncImageSaver(maxQueueCapacity: 20,sleepMs: 30);
        // #3 启动消费者线程
        imageSaver.Start();
        // #4 模拟生产者：模拟相机检测，循环产生存图任务
        Console.WriteLine("\n模拟生产者，产生存图任务，按任意键停止程序...\n");
        var rand = new Random();
        bool runProducer = true;
        // 新开一个模拟生产线程，模拟相机不断产出图片
        Thread producerThread = new Thread(() =>
        {
            int index = 0;
            while(runProducer)
            {
                bool ok = rand.Next(0,2) == 0;
                var task = new ImageSaveHlper
                {
                    Name =$"工位01,img_{index:D6}",
                    Result = ok,
                    SimImageData = $"sim_image_buffer_{index}"
                };
                imageSaver.EnqueueSaveTask(task);
                index++;
                Thread.Sleep(40);   //模拟相机采集间隔
                // `Thread.Sleep(40)` 阻塞的是producerThread 这个生产者子线程，不是主线程。
                // `Thread.Sleep(n)` 的行为：让当前正在执行这条语句的线程休眠 n 毫秒，哪个线程跑这行代码，就卡哪个线程
            }
        })
        {
            IsBackground = true
        };
        producerThread.Start();
        // 等待按键，用户任意键退出
        /*
            流程顺序：先停生产者（不再产生新任务）→ 再关闭消费者（处理已有旧任务）
                1. 用户按下按键；
                2. `runProducer=false` → 通知生产者停止生产；
                3. `producerThread.Join(1000)`：主线原地等待生产者线程收尾；
                4. 生产者跑完当前循环，检测 `runProducer==false`，跳出 while，lambda 方法结束，生产者线程消亡；
                5. 主线从 Join 返回，继续执行 `imageSaver.StopAndWait()`，让消费者线程把队列剩余图片存完。
        */
        Console.ReadKey();
        // 通知生产者停止
        runProducer = false;
        producerThread.Join(1000);  //让当前主线程阻塞等待 `producerThread` 执行结束；最多等待 1000 毫秒，超时不等了直接往下走
        Console.WriteLine("\n收到退出指令，开始优雅关闭存图模块......");
        // 核心：优雅关闭，等待队列剩余图片全部保存完再返回
        imageSaver.StopAndWait();
        Console.WriteLine("\n==== Demo程序退出 ====");
        #endregion
    }
}
