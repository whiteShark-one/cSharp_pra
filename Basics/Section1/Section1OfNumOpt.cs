using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics
{
    public class Section1OfNumOpt
    {
        public void addtionUsingimpData()
        {
            int firstNumber = 12;
            int secondNumber = 8;
            Console.WriteLine(firstNumber + secondNumber);
        }
        public void complexDataAdd()
        {
            string firstName = "Bob";
            int widgeNum =  7;
            Console.WriteLine(firstName + " sold " + widgeNum + " widgehs");
        }
        public void complexDataAddAdvanced()
        {
            string firstName = "Bob";
            int widgetSold = 7;
            Console.WriteLine(firstName + " sold " + widgetSold + 7 + " widegs");
        }
        public void complexDataDivided()
        {
            string firstName = "Bob";
            int widgetSold = 7;
            Console.WriteLine(firstName + " sold " + (widgetSold + 7) + " widegs");
        }
        public void useDemicalToDivide()
        {
            decimal decimalQuotient = 7.0m / 5;
            Console.WriteLine($"D qu: {decimalQuotient}");
            // 有效小数位代码
            decimal decimalQ1 =7 / 5.0m;
            decimal decimalQ2 = 7.0m / 5.0m;
            Console.WriteLine($"Q1 : {decimalQ1}, Q2 : {decimalQ2}");
            // 无效小数代码 -> 需要强转
            int dA = 7 / (int)5.0m;
            int dB = (int)7.0m / 5;
            decimal dD = 7 / 5;
            Console.WriteLine($"da : {dA}, db : {dB}, dd : {dD}");
        }
        // 强制类型转换
        public void intToDecimal()
        {
            int first = 7;
            int second = 5;
            decimal quotient = (decimal)first / (decimal)5;
            Console.WriteLine(quotient);
        }
        // 递增和递减
        public void intPD()
        {
            int value = 1;
            value++;
            Console.WriteLine("First : " + value);
            Console.WriteLine($"Second : {value++}");
            Console.WriteLine($"Third : {++value}");
            Console.WriteLine("Fourth : " + (++value));
        }
        // 华氏温度与摄氏温度转换
        public void tempConvert()
        {
            int fahrenheit = 94;
            // decimal shyrenheit = (fahrenheit - 32) * ((decimal)5 / (decimal)9);
            decimal celsius = (fahrenheit - 32m) * (5m / 9m);
            // Console.WriteLine($"The temperature is {celsius} Celsius.");
            Console.WriteLine("The temperature is " + celsius + "Celsius.");
        }
    }
}