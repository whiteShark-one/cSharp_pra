using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAoiVision.saveImagePro
{
    /// <summary>
    /// 完整异步存图模块（队列、锁、消费者线程、CancellationToken、队列上限）
    /// 异步图片保存模块：生产者消费者模型
    /// 增加：队列最大长度、CancellationToken优雅退出、lock锁保护队列
    /// </summary>
    public class AsyncImageSaver
    {
        #region 定义异步保存图片模块的字段属性
        // 任务队列
        // TODO: 为什么队列只读，却可以向它添加值？
        private readonly Queue<ImageSaveHlper> _imageSaveQueue = new Queue<ImageSaveHlper>();
        // 队列锁对象，入队、出队都要使用该锁
        private readonly object _queueLock = new object();
        // 消费者后台线程
        private Thread? _saveWorkerThread;
        // 取消令牌：优雅退出控制
        private CancellationTokenSource? _cts;
        /// <summary>
        /// 队列最大允许任务数量，超过此数量生产者入队直接丢弃任务并打印告警
        /// </summary>
        public int MaxQueueCapacity { get; }
        /// <summary>
        /// 消费者循环休眠间隙ms
        /// </summary>
        public int SleepMs { get; }
        #endregion

        #region 异步保存图片初始化函数
        public AsyncImageSaver(int maxQueueCapacity = 50, int sleepMs = 30)
        {
            MaxQueueCapacity = maxQueueCapacity;
            SleepMs = sleepMs;
        }
        #endregion

        #region 启动后台消费者线程
        public void Start()
        {
            if (_cts != null)
            {
                Console.WriteLine("[AsyncImageSaver] 已经启动，无需重复调用Start");
                return;
            }
            _cts = new CancellationTokenSource();
            // _saveWorkerThread = new Thread(ConsumerWorker)
            // {
            //     IsBackground = true
            // };
            _saveWorkerThread = new Thread(ConsumerWorker);
            _saveWorkerThread.IsBackground = true;
            _saveWorkerThread.Start();
            Console.WriteLine("[AsyncImageSaver] 存图消费者线程已启动");
        }
        #endregion

        #region 生产者：提交存图任务（外部调用，相机检测后调用）
        public bool EnqueueSaveTask(ImageSaveHlper task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            lock (_queueLock)
            {
                if (_imageSaveQueue.Count >= MaxQueueCapacity)
                {
                    // 队列超限，丢弃任务，打印告警
                    Console.WriteLine($"[警告] 存图队列已满({_imageSaveQueue.Count}/{MaxQueueCapacity})，丢弃任务：{task.Name}");
                    return false;
                }
                _imageSaveQueue.Enqueue(task);
                return true;
            }
        }
        #endregion

        #region 消费者线程主循环
        private void ConsumerWorker()
        {
            // var token = _cts!.Token;
            if (_cts == null)
            {
                throw new InvalidOperationException("CancellationTokenSource未初始化");
            }
            var token = _cts.Token;
            while (true)
            {
                // 收到退出信号
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("[AsyncImageSaver] 收到退出信号，开始处理队列剩余任务...");
                    break;
                }
                ImageSaveHlper? workItem = null;
                lock (_queueLock)
                {
                    if (_imageSaveQueue.Count > 0)
                    {
                        workItem = _imageSaveQueue.Dequeue();
                    }
                }
                if (workItem != null)
                {
                    try
                    {
                        DoSaveImage(workItem);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[异常] 保存图片失败：{ex.Message}");
                    }
                }
                else
                {
                    // 无任务 休眠 降低CPU占用
                    Thread.Sleep(SleepMs);
                }
            }
            // 优雅退出关键：退出主循环后，把队列里残留任务全部处理完毕
            while (true)
            {
                ImageSaveHlper? remainItem = null;
                // 利用lock()保障多线程互斥
                /*
                    保证大括号内部的代码块，同一时刻最多只能有 1 个线程进入执行，保护队列对象，防止多线程同时读写队列产生并发 bug

                */
                lock (_queueLock)
                {
                    if (_imageSaveQueue.Count > 0)
                    {
                        remainItem = _imageSaveQueue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                if (remainItem != null)
                {
                    try
                    {
                        DoSaveImage(remainItem);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[异常] 退出阶段保存残留图片失败：{ex.Message}");
                    }
                }

            }
            Console.WriteLine("[AsyncImageSaver] 所有存图任务处理完成，消费者线程正常结束");
        }
        #endregion

        #region 真正执行保存逻辑，模拟写文件
        public void DoSaveImage(ImageSaveHlper item)
        {
            string[] names = item.Name.Split(',');
            string station = names[0];
            string fileName = names[1];
            string okNg = item.Result ? "OK":"NG";

            // 模拟磁盘IO耗时
            Thread.Sleep(10);

            Console.WriteLine($"[存图] station:{station} | file:{fileName} | {okNg} | SimDataLen:{item.SimImageData.Length}");
        }
        #endregion

        #region 请求优雅关闭，等待线程执行完毕
        public void StopAndWait()
        {
            if (_cts == null)
            {
                Console.WriteLine("[AsyncImageSaver] 未启动，无需停止");
                return;
            }
            // 发送取消信号
            _cts.Cancel();
            // 等线程执行结束，最多等待5秒，防止卡死
            /*
                Join 超时仅仅是 “不再等待”，不会杀掉子线程。
                如果想要子线程退出，必须配合 `CancellationToken` 通知子线程自己退出
            */
            _saveWorkerThread?.Join(5000);

            _cts.Dispose();
            _cts = null;
            _saveWorkerThread = null;
            Console.WriteLine("[AsyncImageSaver] StopAndWait 完成");
        }
        #endregion

    }
}