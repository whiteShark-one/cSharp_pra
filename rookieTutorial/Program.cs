using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
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
            // learnQueue q = new learnQueue();
            // q.optQueueMethod();
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
            Qwen上Task的代码实例
            #endregion
        }
    }
}

