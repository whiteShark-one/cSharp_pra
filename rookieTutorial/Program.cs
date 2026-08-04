using System;
using AdvancedFeature.rookieTutorial;
using cSharp_pra.rookieTutorial;
using rookieTutorial.AdvancedFeature;
// using rookieTutorial;
// using cSharp_pra.rookieTutorial.AdvancedFeature;

// 显示红绿灯信息的委托
public delegate void showMessage(string msg);

// 返回整型结果的委托
public delegate int calcDelegate(int a,int b);

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
            Student[] stus =
            {
                new(1,97,1.57),
                new(2,93,1.60),
                new(3,79,1.55),
                new(4,88,1.50),
                new(5,99,1.64),
                new(6,76,1.49)
            };
            Student.MySort(stus, Student.HeightAsc);
            foreach(Student stu in stus)
            {
                stu.Show();
            }
            
        }
    }
}

