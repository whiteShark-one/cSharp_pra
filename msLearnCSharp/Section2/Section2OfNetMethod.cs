using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.msLearnCSharp.Section2
{
    public class Section2OfNetMethod
    {
        public void useNetMethod()
        {
            // int res = Random.Next(); //有状态方法
            Random dice = new Random();
            int roll = dice.Next();
            // 随机输出 1-7（包含）之间的int整数
            Console.WriteLine(dice.Next(1, 7));
            // 重载Next方法
            int roll1 = dice.Next();    //无上下限，[0-2,147,483,647] -> 后者是int存储的最大值
            int roll2 = dice.Next(101); //上限100，[0-101)，左闭右开
            int roll3 = dice.Next(50, 101);    //指定最小和最大值，[50-101)，左闭右开
            Console.WriteLine($"F roll: {roll1}");
            Console.WriteLine($"S roll: {roll2}");
            Console.WriteLine($"T roll: {roll3}");
            dice.Next();
        }

        // 使用Math类返回两个数字较大的一个
        public int greaterNum(int a, int b)
        {
            int largerValue = Math.Max(a, b);
            // Console.WriteLine(largerValue);
            return largerValue;
        }
    }
}