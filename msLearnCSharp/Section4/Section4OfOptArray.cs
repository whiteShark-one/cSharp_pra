using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.msLearnCSharp.Section4
{
    public class Section4OfOptArray
    {
        /*
            发现Sort()和Reverse()
        */
        public void findSortAndReverse()
        {
            // 创建托盘数据并对其进行排序
            // Array.Sort()
            string[] pallets = ["B14", "A11", "B12", "A13"];
            Console.WriteLine("Sorted...");
            Array.Sort(pallets);
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            // 反转托盘顺序
            // Array.Reverse()
            Console.WriteLine("");
            Console.WriteLine("Reversed...");
            Array.Reverse(pallets);
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }
        }

        // 了解Clear()和Resize()
        public void findClearAndResize()
        {
            // Array.Clear()
            /*
                使用 Array.Clear() 方法可以清除数组中特定元素的内容，从而将其替换为数组的默认值。
                例如，如果清除 string 数组中的元素，则清除的值将替换为 null。 
                同样，在清除 int 数组中的元素时，将替换为 0（零）。
            */
            string[] pallets = ["B14", "A11", "B12", "A13"];
            Console.WriteLine("");
            /*
                使用 Array.Clear() 时，被清除的元素不再引用内存中的字符串。 
                事实上，该元素不指向任何内容。 “不指向任何内容”的概念非常重要，最初可能会难以理解。
            */
            Console.WriteLine($"Before: {pallets[0]}");
            Array.Clear(pallets, 0, 2);
            Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
            Console.WriteLine($"After: {pallets[0]}");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            Console.WriteLine("");
            // Array.Resize()
            /*
                引用类型 + ref 传参
                既能改数组元素，还能修改变量指向，替换成全新数组，Array.Resize 用的就是这个特性
                普通传参只能传地址副本，做不到修改外部数组变量的指向，只能修改数组的元素内容
                ref 允许方法直接操作外面原始变量本身，因此必须写 ref
            */
            Array.Resize(ref pallets, 6);
            Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");
            pallets[4] = "C01";
            pallets[5] = "C02";
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            // 调整数组大小以删除元素
            Console.WriteLine("");
            Array.Resize(ref pallets, 3);
            Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }

            // 是否能从数组中删除 null 元素？
            /*
                如果 Array.Resize() 方法不能从数组中删除空元素，是否存在其他可自动完成此作业的帮助程序方法？ 
                否
                 从数组删除空元素的最佳方式是，通过循环访问每个项并使一个变量（计数器）递增，对非 null 元素进行计数。 
                 接下来，创建另一个与计数器变量大小相同的数组。 最后，循环访问原始数组中的每个元素，并将非 null 值复制到新数组中。
            */
        }

        // 了解Split() 和 Join()
        public void findSplitAndJoin()
        {
            // 使用 ToCharArray() 以反向排列 string
            /*
                ToCharArray() 方法用于创建一个 char 的数组，其中数组的每个元素表示原始字符串的一个字符
            */
            /*
                表达式 new string(valueArray) 会新建 System.String 类的空实例（与 C# 中的 string 数据类型相同），并以构造函数的形式传入字符数组。
            */
            string value = "abc123";
            char[] valueArray = value.ToCharArray();
            Array.Reverse(valueArray);
            string res = new string(valueArray);
            Console.WriteLine(res);

            // 使用 Join()，将所有字符合并为新的逗号分隔值字符串
            /*
                在某些情况下，可能需要使用逗号分隔字符数组的每个元素，这是处理表示为 ASCII 文本的数据时的常见做法.
                使用 String 类的 Join() 方法，传入要用于分段的字符（逗号）和数组本身
            */
            string res2 = String.Join(",",valueArray);
            Console.WriteLine(res2);

            // 对逗号分隔值字符串执行 Split() 操作，以拆分为字符串数组
            /*
                此方法适用于类型 string 的变量，并会创建字符串数组。
            */
            string[] items = res2.Split(',');
            foreach(string item in items)
            {
                Console.WriteLine(item);
            }
        }

        // 练习 - 完成在句子中反向拼写单词的挑战
        public void reverseSpellWords()
        {
            string pangram = "The quick brown fox jumps over the lazy dog";
            string[] items = pangram.Split(' ');
            for (int i = 0; i < items.Length; i++)
            {
                char[] item = items[i].ToCharArray();
                Array.Reverse(item);
                items[i] = new string(item);
            }
            string res = String.Join(" ", items);
            Console.WriteLine(res);

        }

        // 练习 - 完成一项分析订单字符串、对订单进行排序并标记可能错误的挑战
        public void outErrorOrder()
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            string[] items = orderStream.Split(',');
            Array.Sort(items);
            int len = items.Length;
            foreach(string item in items)
            {
                // char[] arr = item.ToCharArray();
                // int arrLen = arr.Length;
                if (item.Length != 4)
                {
                    Console.WriteLine($"{item}\t\t - Error");
                } else
                {
                    Console.WriteLine($"{item}\t\t");
                }
            }
        }
    }
}