using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
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
            var d1 = Direction1.East | Direction1.South;
            Console.WriteLine($"我是Direction1，我有Flags特性，我ToString()后是：");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(d1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            var d2 = Direction1.East | Direction1.South;
            Console.WriteLine($"我是Direction1，我什么也没有，我ToString()后是：");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(d2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            #endregion
        }
    }
}

