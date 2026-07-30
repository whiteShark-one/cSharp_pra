using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics.Section4
{
    public class Section4OfStringNumFormat
    {
        // 练习 - 了解字符串格式设置基础知识
        public void learnStringFormatSet()
        {
            // 注意：不需要将 String.Format() 与此字符串内插方法一起使用。

            // 复合格式设置
            /*
                复合格式化在字符串中使用带编号的占位符。 
                在运行时，大括号内的所有内容都将解析为一个值，该值也是根据大括号的位置传入的。
                此复合格式设置示例对 Format() 数据类型关键字使用 string 内置方法。
            */
            string first = "Hello";
            string second = "World";
            string result = string.Format("{0} {1}!", first, second);
            Console.WriteLine(result);
            Console.WriteLine("{1} {0}", first, second);
            Console.WriteLine("{0} {0} {0}", first, second);

            // 字符串内插
            /*
                “字符串内插”是一种可简化复合格式化的技术。  
                只需使用大括号内的变量名，而不需要使用有编号的标记，并在 String.Format() 或 Console.WriteLine() 参数列表中包括文本值或变量名称。
            */
            /*
                为了对字符串进行插值，必须在其前面加上 $ 指令
            */
            Console.WriteLine($"{first} {second}!");
            Console.WriteLine($"{second} {first}!");
            Console.WriteLine($"{first} {first} {first}!");

            // 设置货币格式
            /*
                复合格式设置和字符串内插可用于根据特定语言和区域性设置显示值的格式。 
                在下面的示例中，:C 货币格式说明符用于将 price 和 discount 变量以货币形式显示。 按以下方式更新您的代码：
            */
            decimal price = 123.45m;
            int discount = 65;
            Console.WriteLine($"Price : {price:C} (Save {discount:C})");

            // 设置数值格式
            /*
                处理数字数据时，可能需要用逗号分隔千位、百万位、十亿位等来设置数字格式，提高其可读性。
                N 数值格式说明符使数字更具可读性。 按以下方式更新您的代码：
                    N 数值格式说明符默认仅显示小数点后两位数字。
                    如果要以更高的精度显示，可通过在说明符后面添加数字来实现。 下面的代码将使用 N4 说明符显示小数点后四位数字。
            */
            decimal measurement = 123456.78912m;
            Console.WriteLine($"Measurement: {measurement:N} units");
            Console.WriteLine($"Measurement: {measurement:N4} units");

            // 设置百分比的格式
            /*
                使用 P 格式说明符设置百分比的格式，并将百分比舍入为 2 个小数位。 
                之后添加一个数字来控制小数点后显示位数。 
            */
            decimal tax = .36785m;
            Console.WriteLine($"Tax rate: {tax:P2}");

            // 结合格式设置方法
            /*
                不需要将 String.Format() 与此字符串内插方法一起使用。
            */
            decimal price2 = 67.55m;
            decimal salePrice = 59.99m;
            string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);
            yourDiscount += $"A discount of {((price - salePrice) / price):P2}!"; //inserted
            Console.WriteLine(yourDiscount);
        }

        // 练习 - 探索字符串内插
        public void findStringInner()
        {
            int invoiceNumber = 1201;
            decimal productShares = 25.4568m;
            decimal subtotal = 2750.00m;
            decimal taxPercentage = .15825m;
            decimal total = 3185.19m;

            Console.WriteLine($"Invoice Number: {invoiceNumber}");
            Console.WriteLine($"   Shares: {productShares:N3} Product");
            Console.WriteLine($"     Sub Total: {subtotal:C}");
            Console.WriteLine($"           Tax: {taxPercentage:P2}");
            Console.WriteLine($"     Total Billed: {total:C}");
        }

        // 练习 - 了解填充和对齐
        /*
            该方法 string.Format() 用于执行复合格式设置，如示例中所示：
        */
        /*
            用于为格式设置添加空白的方法 （PadLeft()， PadRight()）
            比较两个字符串或促进比较的方法（Trim()、TrimStart()、TrimEnd()、GetHashcode()、Length 属性）
            帮助确定字符串内部内容的方法，甚至只检索字符串的一部分（Contains()、StartsWith()、EndsWith()、 Substring()）
            通过替换、插入或删除部分Replace()、（Insert()、 Remove()） 来更改字符串内容的方法
            将字符串转换为字符串或字符数组的方法 （Split()， ToCharArray()）
        */
        public void learnPaddingAndAlignment()
        {
            /*
                该方法 PadLeft() 将空格添加到字符串的左侧，使字符总数等于发送该字符串的参数。 
                在这种情况下，需要字符串的总长度为 12 个字符。
            */
            string input = "Pad this";
            Console.WriteLine(input.PadLeft(12));
            Console.WriteLine(input.PadRight(12));
            Console.WriteLine(input.PadLeft(12, '-'));
            Console.WriteLine(input.PadRight(12, '-'));

            // 使用填充字符串
            string paymentId = "769C";
            string payeeName = "Mr. Stephen Ortega";
            string paymentAmount = "$5,000.00";

            var formattedLine = paymentId.PadRight(6);
            formattedLine += payeeName.PadRight(24);
            formattedLine += paymentAmount.PadLeft(10);

            Console.WriteLine("1234567890123456789012345678901234567890");
            Console.WriteLine(formattedLine);
        }

        // 练习 - 完成将字符串内插应用于套用信函的挑战
        public void accStringInnerLetters()
        {
            string customerName = "Ms. Barros";

            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;

            // Your logic here
            Console.WriteLine($"Dear {customerName},");
            Console.WriteLine($"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.");
            Console.WriteLine("");
            Console.WriteLine($"Currently, you own {currentShares:N} shares at a return of {currentReturn:P}.\n");
            Console.WriteLine($"Our new product, {newProduct} offers a return of {newReturn:P}.  Given your current volume, your potential profit would be {newProfit:C}\n");
            Console.WriteLine("Here's a quick comparison:");

            string comparisonMessage = "";

            // Your logic here
            Console.WriteLine(comparisonMessage);
            // string currentProductLine = currentProduct.PadRight(20);
            // string newProductLine = newProduct.PadRight(20);    
            // Console.WriteLine($"{currentProduct.PadRight(20)}{currentReturn}{currentProfit:C2}");
            // Console.WriteLine($"{newProduct.PadRight(20)}{newReturn:P2.PadRight(9)}{newProfit:C2}");

            /*
                填充PadRight和PadLeft，仅限于用于字符串变量，其他数字类型无法使用添加空格填充
                如果数字类型需要填充对齐，通过String.Format()先格式化字符串，再使用PadRight()
                本例中先设置数字输出格式，再填充对齐
            */
            comparisonMessage = currentProduct.PadRight(20);
            comparisonMessage += String.Format("{0:P}", currentReturn).PadRight(10);
            comparisonMessage += String.Format("{0:C}", currentProfit).PadRight(20);

            comparisonMessage += "\n";
            comparisonMessage += newProduct.PadRight(20);
            comparisonMessage += String.Format("{0:P}", newReturn).PadRight(10);
            comparisonMessage += String.Format("{0:C}", newProfit).PadRight(20);
            Console.WriteLine(comparisonMessage);
        }
    }
}