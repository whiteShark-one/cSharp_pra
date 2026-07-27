using System;
using cSharp_pra.Basics;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World");

            // 菜鸟教程：基本语法
            // SolutionRectangle rectangle = new SolutionRectangle();
            // // rectangle.SayHello(); 
            // rectangle.Acceptdetails();
            // rectangle.Display();
            
            // 单元1：使用 C 中的文本值和变量值存储和检索数据
            // 练习-打印文本值
            Unit1OfTextAndVariables u = new Unit1OfTextAndVariables("Bob", 'm', 98, 12.235m, true);
            // 打印类的成员属性
            // Console.WriteLine(u.ToString);
            // u.PrintPro();
            // u.PrintText();
            // u.PrintTextAndVar();
            Section1OfStringFormat ss = new Section1OfStringFormat();
            // ss.Display();
            // ss.janText();
            // ss.combineStr();
            // ss.innerStr();
            ss.complish();
        }
    }
}

