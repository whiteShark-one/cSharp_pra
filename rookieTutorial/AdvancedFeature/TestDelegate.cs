using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedFeature.rookieTutorial
{
    public class TestDelegate
    {
        /*
        核心特点：
            1、委托有签名规范（返回值、参数列表必须匹配）；
            2、可以把方法当做参数传入另一个方法；
            3、是实现回调、事件的底层基础。
        */
        /*
            Action()
            Func()
            Predicate()
        */
        public static void Log(string content, showMessage printer)
        {
            printer(content);
        }
        // 绿灯
        public void printGreen(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public void printRed(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        // 创建匹配返回整型结果的两个方法
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }

    // event事件 -> 闹钟响铃（触发事件）->手机、人接到通知（订阅者挂载方法并做出响应）
    // #1 定义事件委托（规定事件回调方法签名）
    // 约定：事件委托标准格式 void 方法名（发送者object sender，事件参数 e）
    // public delegate void AlarmEventHandler(object sender, string message);
    class AlarmClock
    {
        // #2 封装委托为事件，基于上面的委托
        // public event AlarmEventHandler alarmRing;
        // #2.1 使用.NET内置事件委托 EventHandler<T> -> 不用手写delegate
        public event EventHandler<string> ?alarmRing;
        // 模拟闹钟到点，触发事件
        // 注意：protected virtual 是C#事件标准写法，让子类可以重写
        protected virtual void onAlarming(string msg)
        {
            alarmRing?.Invoke(this, msg);
        }
        // 对外公开方法，模拟闹钟计时结束
        public void startTiming(int second)
        {
            Console.WriteLine($"闹钟开始计时 {second} ");
            System.Threading.Thread.Sleep(second * 1000);
            // 闹钟响铃
            onAlarming("闹钟响了，时间到!");
        }
    }
    class Person
    {
        public void wakeUp(object sender, string msg)
        {
            Console.WriteLine($"[Person] 收到闹钟通知，{msg} -> 起床");
        }
    }
    class Phone
    {
        public void popNotice(object sender, string msg)
        {
            Console.WriteLine($"[Phone] 收到闹钟通知，{msg} -> 弹出消息");
        }
    }
}