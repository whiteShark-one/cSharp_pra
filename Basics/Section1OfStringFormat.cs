using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics
{
    public class Section1OfStringFormat
    {
        public void Display()
        {
            Console.WriteLine("Hello\nWorld");
            Console.WriteLine("Hello\tWorld");
            // 添加双引号
            Console.WriteLine("Hello \"World\" ");

            Console.WriteLine("Generating invoices for customer \"Contoso Corp\" ... \n");
            Console.WriteLine("Invoice: 1021\t\tComplete!");
            Console.WriteLine("Invoice: 1022\t\tComplete!");
            Console.Write("\nOutput Directory:\t");
            // 使用逐字字符串
            Console.WriteLine(@"    C:\source\repos
                            (this is where you code goes)");
            Console.WriteLine(@"c:\invoices");
            // Kon'nichiwa World
            Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");
        }

        // 生成日语发票
        public void janText()
        {
            Console.WriteLine("Generating invoices for customer \"Contoso Corp\" ... \n");
            Console.WriteLine("Invoice: 1021\t\tComplete!");
            Console.WriteLine("Invoice: 1022\t\tComplete!");
            Console.Write("\nOutput Directory:\t");
            Console.Write(@"c:\invoices");

            // To generate Japanese invoices:
            // Nihon no seikyū-sho o seisei suru ni wa:
            Console.Write("\n\n\u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092\u751f\u6210\u3059\u308b\u306b\u306f\uff1a\n\t");
            // User command to run an application
            Console.WriteLine(@"c:\invoices\app.exe -j");
        }

        // 使用字符串串联合并字符串
        public void combineStr()
        {
            string firstname = "Bob";
            string greeting = "Hello";
            // string message = greeting + " " + firstname + "!";
            // 避免中间变量message
            Console.WriteLine(greeting + " " + firstname + "!");
        }
        
        // 使用字符串内插
        /*
            字符串内插通过使用“模板”和一个/多个内插表达式将多个值合并为单个文本字符串
            内插表达式由一个左大括号和一个右大括号符号 { } 指示。 可将任何返回值的 C# 表达式置于大括号内。 当文本字符串以 $ 字符为前缀时，该字符串将变为模板。
        */
        public void innerStr()
        {
            // 使用字符串内插将文本字符串和变量值合并在一起
            string firstName = "Bob";
            string message = $"Hello {firstName}";
            Console.WriteLine(message);
            // 将字符串内插与多个变量和文本字符一起使用
            int version = 11;
            string update = "Update to Winds";
            string message1 = $"{update} {version}";
            Console.WriteLine(message1);
            // 避免中间变量
            Console.WriteLine($"{update} {version}");
            // 合并逐字文本和字符串内插
            string projectname = "First-Project";
            Console.WriteLine($@"C:\outPut\{projectname}\Data");
        }
        // 完成挑战
        public void complish()
        {
            string projectname = "ACME";
            string engligLocation = @$"C:\Exercise\{projectname}\data.txt";
            string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";
            string russianLocation = @$"C:\Exercise\{projectname}\ru\data.txt";
            // Console.WriteLine(@$"View English Output:
            //     C:\Exercise\{projectname}\data.txt");
            // Console.WriteLine(@$"{russianMessage}:
            //     c:\Exercise\{projectname}\data.txt");
            Console.WriteLine($"View English output:\n\t{engligLocation}");
            Console.WriteLine($"{russianMessage}:\n\t{russianLocation}");
        }
    }
}