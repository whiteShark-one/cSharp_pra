using System;
using System.Collections;
using AdvancedFeature.rookieTutorial;
using cSharp_pra.rookieTutorial;
using rookieTutorial;
using rookieTutorial.AdvancedFeature;
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
        static void Main(string[] args)
        {


            // 菜鸟教程：基本语法
            SolutionRectangle rectangle = new SolutionRectangle();
            // rectangle.SayHello(); 
            // rectangle.Acceptdetails();
            // rectangle.Display();
            // System.Console.WriteLine();

            // 通过回调（将方法作为参数传递）委托，分别调用显示红绿灯方法
            TestDelegate td = new TestDelegate();
            // TestDelegate.Log("操作成功", td.printGreen);
            // TestDelegate.Log("操作失败",td.printRed);

            // 基础委托，委托存放方法
            // calcDelegate op = td.Add;
            // Console.WriteLine(op(1,3));
            // op = td.Sub;
            // Console.WriteLine(op(2,4));

            // 通过回调（将方法作为参数传递）委托，根据学生的Id、Score、Height分别升降序排序显示
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

            // 了解事件，发布者：ProcessManager，订阅者：ProcessMonitor
            // #1 创建发布者manager 和 订阅者monitor
            ProcessManager manager = new ProcessManager();
            ProcessMonitor monitor = new ProcessMonitor();
            // #2 订阅事件（核心） 
            // -> 事件本质是对委托的封装，通过委托 += 挂载订阅者方法，发布者发布事件.Invoke()触发订阅者委托方法执行，实现发布-订阅模型
            // manager.processCreated += monitor.onProcessCreate;
            // manager.createProcess(3373);
            // manager.createProcess(352);
            // manager.createProcess(321);

            // 创建闹钟触发到点事件，通知手机、人
            // AlarmClock alarm = new AlarmClock();
            // Phone phone = new Phone();
            // Person person = new Person();
            // alarm.alarmRing += phone.popNotice;
            // alarm.alarmRing += person.wakeUp;
            // alarm.startTiming(1);

            // 创建结构体
            learnStruct ls = new learnStruct();
            // ls.displayStruct();

            // 了解泛型
            // List<int> list = new List<int>();
            // list.Add(1);
            // list.Add(2);
            learnGeneric lg = new learnGeneric();
            // lg.displayStruct();
            // int a = 3;
            // int b = 9;
            // Console.WriteLine($"{a}, {b}");
            // lg.Swap<int>(ref a, ref b);
            // // lg.Swap<int>(a, b);
            // Console.WriteLine($"{a}, {b}");
            // 另T为string
            string a = "hello";
            string b = "world";
            Console.WriteLine($"{a}, {b}");
            // lg.Swap<string>(ref a, ref b);
            lg.Swap(ref a, ref b);
            // lg.Swap<int>(a, b);
            Console.WriteLine($"{a}, {b}");

        }
    }
}

