using System;
using cSharp_pra.msLearnCSharp;
using cSharp_pra.msLearnCSharp.Section1;
using cSharp_pra.msLearnCSharp.Section2;
using cSharp_pra.msLearnCSharp.Section3;
using cSharp_pra.msLearnCSharp.Section4;
using msLearnCSharp.Section5;

namespace msLearnCSharp
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

            // 部分1：使用 C 中的文本值和变量值存储和检索数据
            // 练习-打印文本值
            Section1OfTextAndVariables u = new Section1OfTextAndVariables("Bob", 'm', 98, 12.235m, true);
            // 打印类的成员属性
            // Console.WriteLine(u.ToString);
            // u.PrintPro();
            // u.PrintText();
            // u.PrintTextAndVar();
            // 部分1：执行基本字符串格式设置
            Section1OfStringFormat ss = new Section1OfStringFormat();
            // ss.Display();
            // ss.janText();
            // ss.combineStr();
            // ss.innerStr();
            // ss.complish();

            // 部分1：对数字进行基本操作
            Section1OfNumOpt sn = new Section1OfNumOpt();
            // sn.addtionUsingimpData();
            // sn.complexDataAdd();
            // sn.complexDataAddAdvanced();
            // sn.complexDataDivided();
            // sn.useDemicalToDivide();
            // sn.intToDecimal();
            // sn.intPD();
            // sn.tempConvert();

            // 部分1：计算和打印学生成绩
            Section1OfPrintStuScore sp = new Section1OfPrintStuScore();
            // sp.calStuToalScore();   // 计算每位同学的加和总成绩
            // sp.calStuAverScore();

            // 部分1：计算最终GPA
            Section1OfCalFinGPA sc = new Section1OfCalFinGPA();
            // sc.storeEveryCourseS();
            // sc.calToalHoursAndGPA();

            // 部分2：调用.NET的方法
            Section2OfNetMethod snm = new Section2OfNetMethod();
            // snm.useNetMethod();
            // int firstValue = 500;
            // int secondValue = 600;
            // int largerValue = snm.greaterNum(firstValue, secondValue);
            // Console.WriteLine($"较大的数字： {largerValue}");

            // 部分2：添加判断逻辑
            Section2OfDecisionLogic sd = new Section2OfDecisionLogic();
            // sd.isRandomEqual();
            // sd.remindRent();

            // 部分2：使用循环数组
            Section2OfForEachAccess se = new Section2OfForEachAccess();
            // se.displayArray();
            // se.useforEach();
            // se.findBOrder();

            // 部分3：使用循环和条件评估学生分数
            Section2OfUseLoopCon su = new Section2OfUseLoopCon();
            // su.estimateStu();
            // su.estimateStuEtrx();

            // 部分3：使用布尔表达式
            Section3OfCalBool s3c = new Section3OfCalBool();
            // s3c.useConOpt();
            // s3c.reverseCoins();
            // s3c.accessPer();

            // 部分3：使用switch-case
            Section3OfSwitchCase s3s = new Section3OfSwitchCase();
            // s3s.switchAndCase();
            // s3s.rewriteIfelseIf();

            // 部分3：使用do-while
            Section3OfWhiledoWhile s3w = new Section3OfWhiledoWhile();
            // s3w.playHeroAndMon();
            // s3w.waitUserInput();
            // s3w.waitUserInputThird();
            // s3w.isInteger();
            // s3w.isstringrole();
            // s3w.dealStrs();

            // 部分3：使用条件和循环
            Section3OfConAndLoop s3l = new Section3OfConAndLoop();
            // s3l.animalMap();

            // 部分4：选择整型类型
            Seciton4OfDataType s4d = new Seciton4OfDataType();
            // s4d.findInteger();
            // s4d.findFloat();

            // 部分4：数据类型转换
            Section4OfDataTypeConversion s4c = new Section4OfDataTypeConversion();
            // s4c.combineIntAndString();
            // s4c.exeDataConversion();
            // s4c.checkTryParse();
            // s4c.combineStringAndNum();
            // s4c.numOptToSpeNum();

            // 部分4：操作数组
            Section4OfOptArray s4o = new Section4OfOptArray();
            // s4o.findSortAndReverse();
            // s4o.findClearAndResize();
            // s4o.findSplitAndJoin();
            // s4o.reverseSpellWords();
            // s4o.outErrorOrder();

            // 部分4：字符串和数字的格式设置
            Section4OfStringNumFormat s4s = new Section4OfStringNumFormat();
            // s4s.learnStringFormatSet();
            // s4s.findStringInner();
            // s4s.learnPaddingAndAlignment();
            // s4s.accStringInnerLetters();

            // 部分4：使用 C# 中的内置字符串数据类型方法修改字符串内容
            Section4OfStringBuildInMethod s4b = new Section4OfStringBuildInMethod();
            // s4b.learnIndexOfAndSubstring();
            // s4b.leadIndexOfAndLastIndexOf();
            // s4b.learnRemoveAndReplace();
            // s4b.dealString();

            // 部分4：在C#中使用变量数据
            Section4OfUseVariables s4u = new Section4OfUseVariables();
            // s4u.useVariablesOne();
            // s4u.accVariablesOne();

            // 部分5：编写C#方法
            Section5OfCreateMethod s5c = new Section5OfCreateMethod();
            // s5c.SayHello();
            // s5c.markReCode();
            // s5c.isIPv4();
            // s5c.tellFortune();

            // 部分5：了解方法范围
            Section5OfCMethodByParam s5p = new Section5OfCMethodByParam();
            // s5p.PrintCircleArea(4);
            // s5p.PrintCircleCircumference(4);
            // int a = 3;
            // int b = 4;
            // int c = 0;
            // s5p.Multiply(a, b, c);
            // Console.WriteLine($"global statement: {a} x {b} = {c}");
            // int[] array = {1, 2, 3, 4, 5};
            // s5p.PrintArray(array);
            // s5p.Clear(array);
            // s5p.PrintArray(array);
            // string status = "Healthy";
            // Console.WriteLine($"Start: {status}");
            // s5p.SetHealth(status, false);
            // Console.WriteLine($"Start: {status}");
            // string msg = "Healthy";
            // Console.WriteLine($"Start: {msg}");
            // s5p.SetHealth2(false);
            // s5p.SetHealth3();
            // 练习：创建RSVP应用程序
            // s5p.RSVP("Rebecca", 1, "none", true);
            // s5p.RSVP("Nadia", 2, "Nuts", true);
            // s5p.RSVP("Linh", 2, "none", false);
            // s5p.RSVP(name: "Linh", partySize: 2, allergies: "none", inviteOnly: false);
            // s5p.RSVP("Tony", 1, "Jackfruit", true);
            // s5p.RSVP("Noor", 4, "none", false);
            // s5p.RSVP("Jonte", 2, "Stone fruit", false);
            // s5p.ShowRSVPs();
            // 练习：显示电子邮件地址
            // s5p.showEmailAdr();

            // 部分5：创建返回值的方法
            Section5OfReturnParm s5r = new Section5OfReturnParm();
            // s5r.initalInput();
            // double usd = 23.73;
            // int vnd = s5r.UsdToVnd(usd);
            // Console.WriteLine($"${usd} USD = ${vnd} VND");
            // Console.WriteLine($"${vnd} VND = ${s5r.VndToUsd(vnd)} USD");
            // Console.WriteLine($"反转字符串：{s5r.ReverseWord("testABCD")}");
            string input = "there are snakes at the zoo";
            // Console.WriteLine(input);
            // Console.WriteLine(s5r.ReverseSentence(input));

            // 从方法中返回布尔值
            string[] words = { "racecar", "talented", "deified", "tent", "tenet" };
            // Console.WriteLine("Is it a palindrome?");

            // 从方法中返回数组
            // int target = 60;
            // int[] coins = new int[] { 5, 5, 50, 25, 25, 10, 5 };
            // int[] result = s5r.TwoCoins(coins, target);
            // Console.WriteLine($"硬币的位置：{result[0]},{result[1]}");

            // int target = 80;
            // int[] coins = new int[] { 5, 5, 50, 25, 25, 10, 5 };
            // int[,] result = s5r.DoubleTwoCoins(coins, target);

            // if (result.Length == 0)
            // {
            //     Console.WriteLine("No two coins make change");
            // }
            // else
            // {
            //     Console.WriteLine("Change found at positions:");
            //     for (int i = 0; i < result.GetLength(0); i++)
            //     {
            //         if (result[i, 0] == -1)
            //         {
            //             break;
            //         }
            //         Console.WriteLine($"{result[i, 0]},{result[i, 1]}");
            //     }
            // }

            // 骰子小游戏
            
            s5r.PlayGame();
        }


    }
}

