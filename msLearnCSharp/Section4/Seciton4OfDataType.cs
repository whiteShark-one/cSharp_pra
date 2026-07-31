using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.msLearnCSharp.Section4
{
    public class Seciton4OfDataType
    {
        /*
            发现整型类型
        */
        public void findInteger()
        {
            // 有符号整型类型
            Console.WriteLine("Signed integral types:");

            Console.WriteLine($"sbyte : {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"short : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long : {long.MinValue} to {long.MaxValue}");

            // 无符号整型类型
            Console.WriteLine("");
            Console.WriteLine("Unsigned integral types:");

            Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
        }

        /* 
            发现浮点数类型
        */
        public void findFloat()
        {
            Console.WriteLine("");
            Console.WriteLine("Floating point types:");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
        }
        /*
            一些数据类型的适用场景
            
            int，适用于大部分整数
            decimal，适用于表示资金的数字
            bool，适用于 true 或 false 值
            string，适用于字母数字值

            byte：用于来自其他计算机系统或使用不同字符集的编码数据。
            double：用于几何学或科研用途。 double 常用于生成涉及运动的游戏。
            System.DateTime，适用于特定的日期和时间值。
            System.TimeSpan，适用于年/月/日/小时/分钟/秒/毫秒范围。
        */

    }
}