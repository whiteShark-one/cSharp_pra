using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics.Section4
{
    public class Section4OfDataTypeConversion
    {
        /*
            执行强制转换
        */
        /*
            编写尝试添加 int 和 string 的代码，并将结果保存在 int 中
        */
        public void combineIntAndString()
        {
            int first = 2;
            string second = "4";
            // int result = first + second;
            string result = first + second;
            Console.WriteLine(result);

            /*
                术语“扩大转换”表示你正在尝试将值从一种可以保留较少信息的数据类型转换为一种可保留较多信息的数据类型。 
                在这种情况下，存储在 int 类型的变量中的值转换为 decimal 类型的变量时不会丢失信息。
            */
            int myInt = 3;
            Console.WriteLine($"int: {myInt}");
            decimal myDecimal = myInt;
            Console.WriteLine($"decimal: {myDecimal}");

            /*
                术语“收缩转换”表示你试图将值从一种可保存较多信息的数据类型转换为一种可保存较少信息的数据类型。 
                在这种情况下，你可能会丢失信息，如精度（即小数点后的位数）。需要强制转换。
            */
            decimal myDecimal1 = 3.14m;
            Console.WriteLine($"decimal1 :　{myDecimal1}");
            int myInt1 = (int)myDecimal1;
            Console.WriteLine($"int1 : {myInt1}");

            /*
                如果不确定在转换过程中是否会丢失数据，请编写代码以两种不同的方式执行转换，并观察变化。
            */
            decimal myDecimal2 = 1.23456789m;
            float myFloat = (float)myDecimal2;
            Console.WriteLine($"Decimal2: {myDecimal}");
            Console.WriteLine($"Float2  : {myFloat}");
        }

        /*
            执行数据转换，包括隐式转换、强制转换和Convert转换
        */
        public void exeDataConversion()
        {
            // 使用ToString() 将数字转换为 string
            /*
                每个数据类型变量都具有 ToString() 方法
            */
            int num1 = 5;
            int num2 = 7;
            string message = num1.ToString() + num2.ToString();
            Console.WriteLine(message);

            // 使用 Parse() 帮助程序方法将 string 转换为 int
            /*
                大部分数字数据类型都具有 Parse() 方法，可将字符串转换为给定的数据类型。
            */
            string s1 = "5";
            string s2 = "7";
            int sum = int.Parse(s1) + int.Parse(s2);
            Console.WriteLine(sum);
            // 使用TryParse()
            int numi;
            bool numb = false;
            numb = int.TryParse(s1, out numi);
            Console.WriteLine(numi);

            // 使用Convert类将string转为int
            /*
                为什么该方法的名称为 ToInt32()？ 为什么不是 ToInt()？ 
                System.Int32 是 .NET 类库中的基础数据类型名称，C# 编程语言将其映射到 int 关键字。 
                由于 Convert 类也属于 .NET 类库，因此调用该类时是按其全名（而非按其 C# 名称）进行调用。
            */
            string value1 = "5";
            string value2 = "7";
            int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
            Console.WriteLine(result);

            // 比较强制转换和将 decimal 转换为 int
            /*
                强制转换 int value = (int)1.5m; 时，系统会截断浮点数的值，因此结果是 1，这意味着完全忽略小数后的值。 
                你可以将文本浮点数更改为 1.999m，强制转换的结果也是相同的。

                使用 Convert.ToInt32() 进行转换时，文本浮点数值将正确地向上舍入到 2。 
                如果你将文本值更改为 1.499m，则会向下舍入到 1。
            */
            /*
                decimal 到 int 是一个收缩转换，因此要舍入，Convert 是最佳答案。
            */
            int v1 = (int)1.5m; // casting truncates
            Console.WriteLine(v1);
            int v2 = Convert.ToInt32(1.5m); // converting rounds up
            Console.WriteLine(v2);
        }

        /*
            检查TryParse()方法
        */
        public void checkTryParse()
        {
            /*
                处理数据时，有时需要将字符串数据转换为数字数据类型。 
                正如上一单元所述，由于字符串数据类型可以保留非数字值，因此将 string 转换为数字数据类型可能导致运行时错误。
            */
            string name = "Bob";
            // Console.WriteLine(int.Parse(name)); // 报错

            /*
                TryParse() 方法可同时执行多项操作：
                    它会尝试将字符串分析成给定的数字数据类型。
                    如果成功，它会将转换后的值存储在 out 参数中，如以下部分所述。
                    它将返回 bool，指示操作是成功还是失败。
                        out 关键字指示编译器，TryParse() 方法不会仅以传统方式返回值（作为返回值），
                        还会通过此双向参数（方法本身返回bool值，out输出转换后的整数值[如果能转化]）传递输出。
            */
            string value = "102";
            int res = 0;
            if (int.TryParse(value, out res))
            {
                Console.WriteLine($"Measurement: {res}");
            }
            else
            {
                Console.WriteLine("Unable to report the measurement.");
            }
            Console.WriteLine($"Measurement (w/ offset): {50 + res}");

            // 将字符串变量修改为无法分析的值
            string value3 = "bad";
            int result = 0;
            if (int.TryParse(value3, out result))
            {
                Console.WriteLine($"Measurement: {result}");
            }
            else
            {
                Console.WriteLine("Unable to report the measurement.");
            }

            if (result > 0)
                Console.WriteLine($"Measurement (w/ offset): {50 + result}");
        }

        // 练习 - 完成将字符串数组值合并为字符串和整数的挑战
        public void combineStringAndNum()
        {
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };
            decimal total = 0m;
            string message = "";
            foreach (string value in values)
            {
                decimal temp = 0m;
                if (decimal.TryParse(value, out temp))
                {
                    total += temp;
                }
                else
                {
                    message += value;
                }
            }
            Console.WriteLine($"Message: {message}");
            Console.WriteLine($"Total: {total}");
        }

        // 练习 - 完成将数学运算输出为特定数字类型的挑战
        public void numOptToSpeNum()
        {
            int value1 = 11;
            decimal value2 = 6.2m;
            float value3 = 4.3f;

            int result1 = Convert.ToInt32(value1/value2);
            decimal result2 = value2 / (decimal)value3;
            float result3 = value3 / value1;

            /* 
                decimal和float互相转换必须强制类型转换，因为十进制和二进制互相不兼容
            */
            float f1 = 3.14f;
            decimal d1 = (decimal)f1;

            /*
                做四则运算时，两边类型不一样，会自动把低精度 / 小范围类型，隐式转成更高精度类型，运算结果统一为高精度类型。 
            */

            // Your code here to set result1
            // Hint: You need to round the result to nearest integer (don't just truncate)
            Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

            // Your code here to set result2
            Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

            // Your code here to set result3
            Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
        }

    }
}