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
}