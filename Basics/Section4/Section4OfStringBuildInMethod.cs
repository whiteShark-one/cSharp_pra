using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics.Section4
{
    public class Section4OfStringBuildInMethod
    {
        // 练习 - 使用字符串的 IndexOf() 和 Substring() 帮助程序方法
        public void learnIndexOfAndSubstring()
        {
            /*
            使用 IndexOf() 方法查找一个或多个字符在较大字符串中的位置。 
            使用 Substring() 方法来返回较大字符串中位于指定字符位置之后的部分
            */
            string message = "Find what is (inside the parentheses)";
            int openingPosition = message.IndexOf('(');
            int closingPosition = message.IndexOf(')');
            // Console.WriteLine(openingPosition);
            // Console.WriteLine(closingPosition);
            /*
                通过将 openingPosition 增加 1，可跳过左括号字符。
                使用该值 1 的原因是，这是字符的长度。 如果尝试查找以较长字符串开头的值，例如， <div> 或者 ---，应改用该字符串的长度。
            */
            openingPosition += 1;
            int length = closingPosition - openingPosition;
            // Console.WriteLine(message.Substring(openingPosition, length)); // 左闭，返回长度为length的子数组
            // Console.WriteLine(message.Substring(openingPosition, length));

            string message2 = "What is the value <span>between the tags</span>?";
            int openingPosition2 = message2.IndexOf("<span>");
            int closingPosition2 = message2.IndexOf("</span>");
            openingPosition2 += 6;
            int length2 = closingPosition2 - openingPosition2;
            // Console.WriteLine(message2.Substring(openingPosition2, length2));

            string message3 = "What is the value <span>between the tags</span>?";
            const string openSpan = "<span>";
            const string closeSpan = "</span>";
            int openingPosition3 = message3.IndexOf(openSpan);
            int closingPosition3 = message3.IndexOf(closeSpan);
            openingPosition3 += openSpan.Length;
            int length3 = closingPosition3 - openingPosition3;
            Console.WriteLine(message3.Substring(openingPosition3, length3));
        }

        // 练习 - 使用字符串的 IndexOf() 和 LastIndexOf() 帮助程序方法
        public void leadIndexOfAndLastIndexOf()
        {
            /*
                .IndexOf() 方法返回给定字符串中指定字符或子字符串的第一个匹配项的索引。 
                .LastIndexOf() 方法返回给定字符串中字符或字符串的最后一个匹配项的索引位置。 
                如果未找到字符或字符串，Indexof() 和 LastIndexOf() 方法均返回 -1。
            */
            // string message = "hello there!";
            // int first_h = message.IndexOf('h');
            // int last_h = message.LastIndexOf('h');
            // Console.WriteLine($"For the message: '{message}', the first 'h' is at position {first_h} and the last 'h' is at position {last_h}.");

            //检索子字符串的最后一个匹配项
            // string message = "(What if) I am (only interested) in the last (set of parentheses)?";
            // int openingPosition = message.LastIndexOf('(');
            // openingPosition += 1;
            // int closingPosition = message.LastIndexOf(')');
            // int length = closingPosition - openingPosition;
            // Console.WriteLine(message.Substring(openingPosition, length));

            // 检索括号内子字符串的所有实例
            // string message = "(What if) there are (more than) one (set of parentheses)?";
            // while (true)
            // {
            //     int openingPosition = message.IndexOf('(');
            //     if (openingPosition == -1) break;
            //     openingPosition += 1;
            //     int closingPosition = message.IndexOf(')');
            //     int length = closingPosition - openingPosition;
            //     Console.WriteLine(message.Substring(openingPosition, length));

            //     // Note the overload of the Substring to return only the remaining 
            //     // unprocessed message:
            //     message = message.Substring(closingPosition + 1);
            // }

            // 使用 IndexOfAny() 处理不同类型的符号集
            /*
                使用 .IndexOfAny() 搜索几个不同的字符符号，而不仅仅是一组括号。
                .IndexOfAny() 报告提供的字符数组中任意字符的 数组message第一个匹配项 的索引。 如果未在字符数组中找到任何字符，则该方法返回 -1。
            */
            // string message = "Hello, world!";
            // char[] charsToFind = { 'o', 'e', 'i' };
            // int index = message.IndexOfAny(charsToFind);
            // Console.WriteLine(message[2]);
            // Console.WriteLine($"Found '{message[index]}' in '{message}' at index:{index}");
            // string message = "Help (find) the {opening symbols}";
            // Console.WriteLine($"Searching THIS Message: {message}");
            // char[] openSymbols = {'[', '{', '('};
            // int startPosition = 5;
            // int openingPosition = message.IndexOfAny(openSymbols);
            // Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");
            // openingPosition = message.IndexOfAny(openSymbols, startPosition);
            // Console.WriteLine($"Found WITH using startPosition {startPosition} : {message.Substring(openingPosition)}");
            // 输出() [] {}内的字符内容
            string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";
            // char[] openSymbols = {'(', '[', '{'};
            // char[] closeSymbols = {')', ']', '}'};
            // int openPos = 0;
            // int closePos = 0;
            // while (true)
            // {
            //     openPos = message.IndexOfAny(openSymbols);
            //     if (openPos == -1) break;

            //     closePos = message.IndexOfAny(closeSymbols);
            //     openPos += 1;
            //     int len = closePos - openPos;
            //     Console.WriteLine(message.Substring(openPos, len));
            //     message = message.Substring(closePos + 1);
            // }
            char[] openSymbols = { '(', '[', '{' };
            int closingPos = 0;
            while (true)
            {
                int openingPos = message.IndexOfAny(openSymbols, closingPos);
                if (openingPos == -1) break;
                string currentSymbol = message.Substring(openingPos, 1);
                char matchingSymbol = ' ';

                switch (currentSymbol)
                {
                    case "(":
                        matchingSymbol = ')';
                        break;
                    case "[":
                        matchingSymbol = ']';
                        break;
                    case "{":
                        matchingSymbol = '}';
                        break;
                }
                openingPos += 1;
                closingPos = message.IndexOf(matchingSymbol, openingPos);
                int len = closingPos - openingPos;
                Console.WriteLine(message.Substring(openingPos, len));
            }
        }

        // 练习 - 使用 Remove() 和 Replace() 方法
        public void learnRemoveAndReplace()
        {
            /*
                使用 Remove() 该方法从字符串中删除字符
                使用该方法 Replace() 替换字符
            */
            string data = "12345John Smith          5000  3  ";
            string updatedData = data.Remove(5, 20);
            Console.WriteLine(updatedData);

            string message = "This--is--ex-amp-le--da-ta";
            message = message.Replace("--", " ");
            message = message.Replace("-", " ");
            Console.WriteLine(message);
        }

        // 练习 - 完成从输入字符串中提取、替换和删除数据的挑战
        public void dealString()
        {
            const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

            string quantity = "";
            string output = input;

            // Your work here
            string spanBefore = "<span>";
            string spanAfter = "</span>";
            int spanBeforePos = output.IndexOf(spanBefore);
            int spanAfterPos = output.IndexOf(spanAfter);
            spanBeforePos += spanBefore.Length;
            int spanLen = spanAfterPos - spanBeforePos;
            quantity = output.Substring(spanBeforePos, spanLen);
            // output = output.Replace("<div>", "");
            // output = output.Replace("</div>", "");
            // 使用Remove()去掉<div>和</div>
            const string openDiv = "<div>";
            int divStartPos = output.IndexOf(openDiv);
            output = output.Remove(divStartPos, openDiv.Length);
            const string closeDiv = "</div>";
            int divEndPos = output.IndexOf(closeDiv);
            output = output.Remove(divEndPos, closeDiv.Length);
            output = output.Replace("&trade","&reg");
            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Output: {output}");

        }
    }
}