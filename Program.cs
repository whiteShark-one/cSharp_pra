using System;
using cSharp_pra.Basics;
using cSharp_pra.Basics.Section2;
using cSharp_pra.Basics.Section3;
using cSharp_pra.Basics.Section4;

namespace CSharp
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
            s4o.outErrorOrder();
        }
    }
}

