using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using AdvancedFeature.rookieTutorial;
using cSharp_pra.rookieTutorial;
using rookieTutorial;
using rookieTutorial.AdvancedFeature;
using rookieTutorial.AsyncMultiThread;
using rookieTutorial.Basics;
// using rookieTutorial;
// using cSharp_pra.rookieTutorial.AdvancedFeature;

// 显示红绿灯信息的委托
public delegate void showMessage(string msg);

// 返回整型结果的委托
public delegate int calcDelegate(int a, int b);

namespace CSharp
{
    class Program
    {
        static async Task Main(string[] args)
        // static void Main(string[] args)
        {


            #region 菜鸟教程：基本语法
            SolutionRectangle rectangle = new SolutionRectangle();
            // rectangle.SayHello(); 
            // rectangle.Acceptdetails();
            // rectangle.Display();
            // System.Console.WriteLine();
            #endregion

            #region  通过回调（将方法作为参数传递）委托，分别调用显示红绿灯方法
            TestDelegate td = new TestDelegate();
            // TestDelegate.Log("操作成功", td.printGreen);
            // TestDelegate.Log("操作失败",td.printRed);
            #endregion

            #region 基础委托，委托存放方法
            // calcDelegate op = td.Add;
            // Console.WriteLine(op(1,3));
            // op = td.Sub;
            // Console.WriteLine(op(2,4));
            #endregion

            #region 通过回调（将方法作为参数传递）委托，根据学生的Id、Score、Height分别升降序排序显示
            // Student[] stus =
            // {
            //     new(1,97,1.57),
            //     new(2,93,1.60),
            //     new(3,79,1.55),
            //     new(4,88,1.50),
            //     new(5,99,1.64),
            //     new(6,76,1.49)
            // };
            // Student.MySort(stus, Student.HeightAsc);
            // foreach(Student stu in stus)
            // {
            //     stu.Show();
            // }
            #endregion

            #region  了解事件，发布者：ProcessManager，订阅者：ProcessMonitor
            // #1 创建发布者manager 和 订阅者monitor
            ProcessManager manager = new ProcessManager();
            ProcessMonitor monitor = new ProcessMonitor();
            // #2 订阅事件（核心） 
            // -> 事件本质是对委托的封装，通过委托 += 挂载订阅者方法，发布者发布事件.Invoke()触发订阅者委托方法执行，实现发布-订阅模型
            // manager.processCreated += monitor.onProcessCreate;
            // manager.createProcess(3373);
            // manager.createProcess(352);
            // manager.createProcess(321);
            #endregion

            #region  创建闹钟触发到点事件，通知手机、人
            AlarmClock alarm = new AlarmClock();
            // Phone phone = new Phone();
            // Person person = new Person();
            // alarm.alarmRing += phone.popNotice;
            // alarm.alarmRing += person.wakeUp;
            // alarm.startTiming(1);
            #endregion

            #region 了解反射和特性
            // ReflectionAndAttribute ra = new ReflectionAndAttribute();
            // Cow cow = new Cow()
            // {
            //     Id = 12,
            //     Name = "Tom",
            //     Age = 19,
            //     Gender = Gender.Male,
            //     Class = "3A"
            // };
            // Console.WriteLine(MyJsonConvert.SerializeObject(cow));
            // Student stu = new Student()
            // {
            //     Id = 13,
            //     Score = 98,
            //     Height = 180
            // };
            // Console.WriteLine(MyJsonConvert.SerializeObject(stu));
            #endregion

            #region 简单反射示例
            // #1 获取Type对象，拿到Student全部说明说
            // Type t = typeof(Student);
            // Console.WriteLine("类名：" + t.Name);
            // // #2 运行时动态创建实例，等价于 new Student()
            // Object obj = Activator.CreateInstance(t);
            // // #3 拿到属性信息，给Name复制
            // PropertyInfo prop = t.GetProperty("Id");
            // prop.SetValue(obj,11);
            // // #4 获取方法，动态调用Show()
            // MethodInfo method = t.GetMethod("Show");
            // method.Invoke(obj,null);    //Invoke 执行方法，参数null代表无参数
            #endregion

            #region 使用反射读取自定义标签 （特性只能通过反射才能取出）
            /*
            执行流程：
                #1. 写一个继承`Attribute`的自定义特性
                #2. 在类 / 方法上用`[xxx]`打上标签（存入元数据）
                #3. 通过反射拿到`Type / MethodInfo`
                #4. `GetCustomAttribute<T>()`读取标签数据
                #5. 根据读到的数据，执行自己业务逻辑

            */
            // Type stuType = typeof(Student);
            // // 获取类上面贴的AuthorAttribute特性
            // var authorAttr = stuType.GetCustomAttribute<AuthorAttribute>();
            // if (authorAttr != null)
            // {
            //     Console.WriteLine($"作者：{authorAttr.Name},版本：{authorAttr.Version}");
            // }
            // // 获取Study方法上面的特性
            // MethodInfo m = stuType.GetMethod("Study");
            // var methodAttr = m.GetCustomAttribute<AuthorAttribute>();
            // Console.WriteLine($"Study方法作者：{methodAttr.Name}");
            #endregion

            #region 使用特性实现测试需求：写一个简单工具，扫描类，把所有标记`[MyTest]`的方法自动执行（简易单元测试）
            // Type t = typeof(TestDemo);
            // object o = Activator.CreateInstance(t);
            // // 获取该类的全部public实例方法
            // MethodInfo[] methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            // foreach (var method in methods)
            // {
            //     // 判断方法上是否有[MyTest]标签
            //     var attr = method.GetCustomAttribute<MyTestAttribute>();
            //     if (attr != null)
            //     {
            //         Console.WriteLine($"发现测试方法: {method.Name}");
            //         method.Invoke(o,null);  // 动态调用
            //     }
            // }
            #endregion

            #region 动态创建对象、读写属性、调用普通方法
            // Type stuType = typeof(Student);
            // // #1 动态 new Student()
            // object stuObj = Activator.CreateInstance(stuType);
            // // #2 设置属性
            // PropertyInfo propId = stuType.GetProperty("Id");
            // propId.SetValue(stuObj, 13);
            // PropertyInfo propScore = stuType.GetProperty("Score");
            // propScore.SetValue(stuObj,98);
            // PropertyInfo propHeight = stuType.GetProperty("Height");
            // propHeight.SetValue(stuObj,1.50);
            // // #3 读取属性
            // var valId = propId.GetValue(stuObj);
            // Console.WriteLine($"读取Id：{valId}"); 
            // var valScore = propScore.GetValue(stuObj);
            // Console.WriteLine($"读取Score：{valScore}");
            // var valHeight = propHeight.GetValue(stuObj);
            // Console.WriteLine($"读取Height：{valHeight}");
            // // #4 获取方法，调用带参数的sayHi
            // MethodInfo methodSH = stuType.GetMethod("sayHi");
            // methodSH.Invoke(stuObj,new object[]{"早上好"});
            #endregion

            #region 反射读取自定义特性
            // Type stuType = typeof(Student);
            // var remark = stuType.GetCustomAttribute<RemarkAttribute>();
            // if (remark != null)
            // {
            //     Console.WriteLine($"类注释：{remark.Info}");
            // }
            #endregion

            #region 自定义标签控制校长、教师是否以Json格式进行输出
            // var shcools = new List<School>
            // {
            //     new Principal
            //     {
            //         Id = 1,
            //         Name = "l校长",
            //         Office = "熊战士"
            //     },
            //     new Teacher
            //     {
            //         Id = 2,
            //         Name = "s教师",
            //         Level = "特级教师"
            //     }
            // };
            // foreach(var school in shcools)
            // {
            //     Console.WriteLine(school);
            //     Console.WriteLine();
            // }
            #endregion

            #region 特性控制方向输出
            // var d1 = Direction1.East | Direction1.South;
            // Console.WriteLine($"我是Direction1，我有Flags特性，我ToString()后是：");
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine(d1);
            // Console.ForegroundColor = ConsoleColor.White;
            // Console.WriteLine();
            // var d2 = Direction1.East | Direction1.South;
            // Console.WriteLine($"我是Direction1，我什么也没有，我ToString()后是：");
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine(d2);
            // Console.ForegroundColor = ConsoleColor.White;
            // Console.WriteLine();
            #endregion

            #region 了解队列Queue
            learnQueue q = new learnQueue();
            // q.optQueueMethod();
            // q.optConcurrentQueue();
            // Thread producer = new Thread(learnQueue.Producer);
            // Thread consumer = new Thread(learnQueue.Consumer);
            // producer.Start();
            // consumer.Start();
            // producer.Join();
            #endregion

            #region 了解多线程
            // Thread th = Thread.CurrentThread;
            // th.Name = "MainThread";
            // Console.WriteLine("This is {0}",th.Name);
            // Console.WriteLine();
            learnThread lt = new learnThread();
            // #1 创建线程
            // lt.createNewThread();
            // #2 管理线程
            // #3 销毁线程
            // 终止子线程
            // Console.WriteLine("In Main: Aborting the Child thread");

            // Task + CancellationTokenSource + CancellationToken
            // using CancellationTokenSource cts = new CancellationTokenSource();
            // Task.Run 把工作放到线程池后台执行
            // var task = Task.Run(async () =>
            // {
            //     await lt.learnCancellationTokenSource(cts.Token);
            // }, cts.Token);

            // Console.WriteLine("按任意键取消");
            // Console.ReadKey();
            // 发出取消信号
            // cts.Cancel();
            // try
            // {
            //     await task;
            // }
            // catch (OperationCanceledException)
            // {
            //     Console.WriteLine("任务被正常取消");
            // }
            // Console.WriteLine("程序结束");

            #endregion

            #region 线程创建的4种方式
            // MultiThread multiThread = new MultiThread();
            // #1 Thread类
            // MultiThread.ThreadMethod();

            // 员工干活的例子（包含Join()的用法）
            // Thread worker = new Thread(() =>
            // {
            //     Console.WriteLine("员工：开始搬砖...");
            //     Thread.Sleep(3000); // 模拟干活3秒
            //     Console.WriteLine("员工：搬砖结束");
            // }); 
            // worker.Start();

            // Join()的用法: 老板（主线程）在这里被阻塞，等待 worker 结束
            // Console.WriteLine("老板：我在等员工干完活...");
            // worker.Join();
            // Console.WriteLine("老板：员工干完了，我继续去开会。");
            // Join()超时：
            // bool isFinished = worker.Join(2000);
            // if(isFinished)
            // {
            //     Console.WriteLine("员工在2s内干完了");
            //     Console.WriteLine("老板：员工干完了，我继续去开会。");
            // } else
            // {
            //     Console.WriteLine("超时了不等，老板先走了");
            // }
            // isBackground()用法：设置为后台线程，进程结束会被直接杀死
            // 保洁打扫卫生（包含IsBackground()的用法） -> 如果被设置为后台线程，若未执行完毕，会被进程直接杀死
            // Thread cleaner = new Thread(() =>
            // {
            //     Console.WriteLine("保洁开始打扫卫生");
            //     Thread.Sleep(3000);
            //     Console.WriteLine("保洁：打扫完毕！（这句话永远不会打印）");
            // });
            // cleaner.IsBackground = true;
            // cleaner.Start();
            // 主线程 join等待后台线程
            // Console.WriteLine("老板要等保洁打扫完再下班");
            // cleaner.Join();
            // Console.WriteLine("保洁已经打扫完，老板也下班了");
            // Console.WriteLine("老板（主线程/前台）：今天工作结束，我下班了！");// 主线程（前台）执行完毕。此时 CLR 发现没有前台线程了，直接关闭进程。保洁阿姨（后台线程）被瞬间强制杀死。

            // #2 ThreadPool
            // MultiThread.ThreadPoolMethod();

            // #3 Task
            // 无返回值
            // Task t = Task.Run(() =>
            // {
            //     Console.WriteLine("Task运行在线程池");
            //     Thread.Sleep(1000);
            // });
            // 带返回值
            // Task<int> t2 = Task.Run(() =>
            // {
            //     return 100;
            // });
            // int res = await t2;
            // Console.WriteLine($"res的值：{res}");
            // await t;
            // 支持取消 CancellationTokenSource
            /*
                - `CancellationTokenSource` → 控制器，你来调用 `cts.Cancel()` 发取消信号
                - `cts.Token` → 令牌，传给任务，任务内部监视这个令牌
                - `ThrowIfCancellationRequested()`：检查是否收到取消信号，如果收到，直接抛异常终止任务
            */
            // using var cts = new CancellationTokenSource();
            // CancellationToken token = cts.Token;
            // Task t3 = Task.Run(async () =>
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         // 每一轮循环检测是否取消
            //         token.ThrowIfCancellationRequested();
            //         Console.WriteLine($"正在运行i= {i}");
            //         // 把token传给Delay，Delay内部会监听取消信号
            //         await Task.Delay(300,token);
            //     }
            // }, token);
            // Console.WriteLine("按任意键取消任务");
            // Console.ReadKey();
            // // 发出取消信号
            // cts.Cancel();
            // try
            // {
            //     await t3;
            // }
            // catch
            // {
            //     Console.WriteLine("任务被正常取消");
            // }
            // Qwen上Task的代码实例
            // 例 1：基础用法（无返回值 & 有返回值）
            // 例 2：并行执行多个任务（Task.WhenAll）
            // 场景：同时下载 3 个文件，全部下载完再合并。
            // Console.WriteLine("=== 例2：并行异步下载多个文件 ===");
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // Task<string> t1 = MultiThread.DownloadAsync("文件A", 1000);
            // Task<string> t2 = MultiThread.DownloadAsync("文件B", 2000);
            // Task<string> t3 = MultiThread.DownloadAsync("文件C",1500);
            // string[] results = await Task.WhenAll(t1,t2,t3);
            // sw.Stop();
            // Console.WriteLine($"所有下载完成，结果: {string.Join(", ", results)}");
            // Console.WriteLine($"总耗时: {sw.ElapsedMilliseconds}ms"); 
            // 输出约 2000ms（取最慢的那个），而不是 1000+2000+1500=4500ms
            // 例 3：竞速模式与超时控制（Task.WhenAny）
            // 场景：调用一个接口，如果 3 秒内没返回，就认为超时。
            // Console.WriteLine("=== 例3：超时控制 ===");
            // Task<string> apiTask = MultiThread.CallSlowAsync();
            // Task timeoutTask = Task.Delay(3000);
            // Task completedTask = await Task.WhenAny(apiTask,timeoutTask);
            // if(completedTask == timeoutTask)
            // {
            //     Console.WriteLine("❌ 请求超时！");
            // } else
            // {
            //     string data = await apiTask;
            //     Console.WriteLine($"✅ 获取数据: {data}");
            // }
            // 例 4：取消任务（CancellationToken）
            // 场景：用户点击“取消下载”按钮。
            // Console.WriteLine("=== 例4：取消任务 ===");
            // using CancellationTokenSource cts = new CancellationTokenSource();
            // CancellationToken token = cts.Token;
            // // 模拟：3s后自动取消
            // cts.CancelAfter(2000);
            // try
            // {
            //     await Task.Run(async () =>
            //     {
            //         Console.WriteLine("开始下载大文件...");
            //         for (int i = 0; i < 10; i++)
            //         {
            //             // 检查是否被取消
            //             token.ThrowIfCancellationRequested();
            //             Console.WriteLine($"下载进度: {(i + 1) * 10}%");
            //             await Task.Delay(400);
            //             // Thread.Sleep(400); // Task.Delay和Thread.sleep有什么区别？
            //         }
            //         Console.WriteLine("下载完成");
            //     },token);
            // } catch(OperationCanceledException)
            // {
            //     Console.WriteLine("任务已被用户取消");
            // }
            // 例 5：异常处理
            // Console.WriteLine("=== 例5：异常处理 ===");
            // try
            // {
            //     Task t1 = Task.Run(() => throw new Exception("task1出现问题"));
            //     Task t2 = Task.Run(() => {throw new Exception("task2也坏了");});
            //     await Task.WhenAll(t1,t2);
            // }catch(Exception ex)
            // {
            //     Console.WriteLine($"捕获到异常: {ex.Message}");
            //     // ⚠️ 注意：await 只抛出第一个异常。
            //     // 如果需要获取所有异常，需要检查 Task.Exception（AggregateException）
            //     // 但在 async/await 模式下，通常捕获第一个就够了。
            // }
            // 例 6：真正的异步 IO（不占用线程）
            // 核心区别：Task.Run 是占用一个线程池线程去干活（CPU 密集）。而真正的异步 IO（如 HttpClient、FileStream）是操作系统层面的异步，等待期间不占用任何线程。
            // Console.WriteLine("=== 例6：真正的异步 IO ===");
            // using HttpClient httpClient = new HttpClient();
            // Console.WriteLine("发起请求..");
            // // 这里不会阻塞线程！线程被释放回线程池去处理其他请求。
            // // 等网络响应回来后，线程池再分配一个线程继续执行后续代码。
            // string html = await httpClient.GetStringAsync("https://example.com");
            // Console.WriteLine($"获取到 {html.Length} 个字符");

            // #4 Parallel类
            // 例1：Parallel.Invoke —— 并行执行多个独立任务
            // Console.WriteLine("=== 例1：Parallel.Invoke ===");
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // Parallel.Invoke(
            //     () => MultiThread.InitializeDatabase(),
            //     () => MultiThread.LoadConfiguration(),
            //     () => MultiThread.WarmUpCache()
            // );
            // sw.Stop();
            // Console.WriteLine($"耗时：{sw.ElapsedMilliseconds}");
            // 例 2：Parallel.For —— 并行处理数值计算
            // 场景：计算 1 到 10000 每个数的平方（CPU 密集型）。
            // Console.WriteLine("=== 例2：Parallel.For ===");
            // long[] res = new long[10000];
            // // 并行执行 0 到 9999
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // Parallel.For(0,10000,i =>
            // {
            //     res[i] = i * i;
            // });
            // Console.WriteLine($"计算完成，第 100 个结果: {res[100]}");
            // sw.Stop();
            // Console.WriteLine($"耗时：{sw.ElapsedMilliseconds}");
            // 例3：Parallel.ForEach —— 并行处理集合
            // 模拟获取一批文件路径
            // var files = new List<string> { "img1.jpg", "img2.jpg", "img3.jpg", "img4.jpg" };
            // Parallel.ForEach(files, file =>
            // {
            //     Console.WriteLine($"正在处理 {file}，线程: {Environment.CurrentManagedThreadId}");
            //     Thread.Sleep(1000); // 模拟耗时的图片压缩
            //     Console.WriteLine($"{file} 处理完成！");
            // });
            // Console.WriteLine("所有图片处理完毕！");
            // 例 4：使用 ParallelOptions 控制并发度 + 取消
            // 场景：限制最多同时处理 4 个文件，避免内存爆炸；支持用户取消。
            // Console.WriteLine("=== 例4：ParallelOptions ===");
            // using CancellationTokenSource cts = new();
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // 模拟 5s后自动取消
            // cts.CancelAfter(5000);
            // var options = new ParallelOptions
            // {
            //     MaxDegreeOfParallelism = 4, //最多使用4个线程
            //     CancellationToken = cts.Token
            // };
            // var items = Enumerable.Range(1, 20).ToList();
            // try
            // {
            //     Parallel.ForEach(items, options, item =>
            //     {
            //         // 检查取消
            //         options.CancellationToken.ThrowIfCancellationRequested();
            //         Console.WriteLine($"处理项目 {item}");
            //         Thread.Sleep(100);
            //     });
            //     Console.WriteLine("✅ 全部完成！");
            // }
            // catch (OperationCanceledException)
            // {
            //     Console.WriteLine("⚠️ 任务被取消！");
            // }
            // sw.Stop();
            // Console.WriteLine($"耗时：{sw.ElapsedMilliseconds}");
            // 例 5：使用 ParallelLoopState 提前退出
            // 场景：在集合中查找第一个满足条件的元素，找到后立即停止。
            // Console.WriteLine("=== 例5：ParallelLoopState ===");
            // var numbers = Enumerable.Range(1, 1000000).ToList();
            // int foundNumber = -1;
            /*
                Parallel.ForEach()的重载版本 对应的委托签名 -> Action<TSource, ParallelLoopState, long> 
                    - 这个重载没有线程本地状态，第三个参数就是元素索引。
                    - num → TSource：当前循环拿到的集合元素（这里就是 numbers 里的 int 数字）
                    - state → ParallelLoopState：循环状态对象，用来控制并行循环，state.Stop() / state.Break() 就在这用
                    - index → long：当前元素在集合里的索引
            */
            // Parallel.ForEach(numbers, (num, state, index) =>
            // {
            //     // 模拟查找：找到能被 999983 整除的数
            //     if (num % 999983 == 0)
            //     {
            //         foundNumber = num;
            //         Console.WriteLine($"找到了！{num}，索引: {index}");

            //         //立即停止所有迭代（不再处理后续批次）
            //         state.Stop();
            //         return;
            //     }
            // });
            // Console.WriteLine($"最终结果: {foundNumber}");

            Console.WriteLine("=== 例6：线程本地状态 ===");
            var numbers = Enumerable.Range(1, 10000000).ToList();
            long total = 0;
            // 低效写法
            // Parallel.ForEach(numbers, num =>
            // {
            //     Interlocked.Add(ref total, num); // 一千万次原子操作！很慢
            // });
            // 这个模式在并行聚合（求和、计数、统计）中极其常用，能大幅减少锁竞争，性能提升数倍。
            /*
                Func<TSource, ParallelLoopState, TLocal, TLocal>
                这里第三个参数不再是索引！名字只是变量名，叫`localSum`，它是这个线程分区专属的本地状态。
                这个委托是`Func`，必须 return 更新后的本地状态。
            */
            /*
            Parallel 内部工作机制：
            1. Parallel 会把数据源切分成多个分区，每个分区交给一个线程处理。
            2. 当线程开始处理自己分区前，执行`localInit ()=>0L`，生成一个初始值`0L`，这个值绑定到当前这个线程 / 分区。
            3. 每处理一个元素，调用 body Func：传入当前分区绑定的`localSum`。
            4. 在 body 里面累加，`return localSum`，Parallel 框架把返回值存回这个分区的本地状态，供这个线程下一次迭代继续使用。
            > 
            > 不同分区（不同线程）有各自独立的`localSum`，互不共享，互不干扰。
            > 所以多个线程同时执行 body 代码，修改各自的 localSum，不存在竞态，不需要锁。

            ```
            线程A分区 → localSumA
            线程B分区 → localSumB
            线程C分区 → localSumC
            ```

            三个是独立变量，不是同一个共享变量。

            > 
            > 注意：这不是 C# 自动给线程创建 ThreadLocal，**是 Parallel 框架内部帮你维护每个分区对应的 TLocal 对象**。
            */
            Parallel.ForEach(
                numbers,
                // 1. localInit: 每个线程初始化自己的局部变量
                () => 0L,
                // 2. body: 每个迭代的逻辑，返回更新后的局部变量
                (num, state, localSum) =>
                {
                    localSum += num;
                    return localSum;
                },
                // 3. localFinally: 每个线程结束时，将局部结果合并到全局
                localSum =>
                {
                    Interlocked.Add(ref total, localSum); // 线程安全的加法
                }
            );

            Console.WriteLine($"总和: {total}");
            #endregion

            #region Action/Func/Event/Lambda详解
            #endregion
        }
    }
}

