using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.msLearnCSharp.Section3
{
    public class Section3OfWhiledoWhile
    {
        /*
            循环计算英雄和坏人的攻击
        */
        public void playHeroAndMon()
        {
            int herob = 10;
            int monb = 10;
            // int order = 0; //攻击次序
            Random random = new Random();
            do
            {
                int attack = random.Next(1, 11);
                // 决定攻击次序
                // if ((order % 2) == 0)
                // {
                //     // 英雄攻击
                //     monb -= attack;
                //     Console.WriteLine($"Monster was damaged and lost {attack} health and now has {monb - attack} health.");
                // } else
                // {
                //     herob -= attack;
                //      Console.WriteLine($"Hero was damaged and lost {attack} health and now has {monb - attack} health.");
                // }
                monb -= attack;
                Console.WriteLine($"Monster was damaged and lost {attack} health and now has {monb} health.");
                if (monb <= 0) continue;

                attack = random.Next(1, 11);
                herob -= attack;
                Console.WriteLine($"Hero was damaged and lost {attack} health and now has {monb} health.");


            } while (herob > 0 && monb > 0);

            // 输出胜者
            string winner = herob > monb ? "herob" : "monb";
            Console.WriteLine(winner);

        }

        /*
            质询循环等待用户输入
        */
        public void waitUserInput()
        {
            string? readResult;
            Console.WriteLine("Enter a string:");
            do
            {
                readResult = Console.ReadLine();

            } while (readResult == null);
        }
        /*
            质询循环等待用户三个字符输入
        */
        public void waitUserInputThird()
        {
            string? readResult;
            bool validEntry = false;
            Console.WriteLine("Enter a string containing at least three characters:");
            do
            {
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    if (readResult.Length >= 3)
                    {
                        validEntry = true;
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid, please try again.");
                    }
                }
            } while (validEntry == false);
        }
        /*
            编写验证整型输入的代码
        */
        public void isInteger()
        {
            string? readResult;
            string valueEntered = "";
            int numericValue = 0;
            bool validNumber = false;

            Console.WriteLine("Enter a int between 5 and 10:");
            do
            {
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    valueEntered = readResult;
                }

                // 使用int.TryParse()方法
                validNumber = int.TryParse(valueEntered, out numericValue);
                if (!validNumber)
                {
                    Console.WriteLine("请输入整数");
                }
                else
                {
                    if (numericValue >= 5 && numericValue <= 10)
                    {
                        validNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("请输入介于5到10之间的整数");
                    }
                }
            } while (validNumber == false);
        }
        /*
            编写验证字符串输入的代码
        */
        public void isstringrole()
        {
            string? readResult;
            string roleName = "";
            bool validEntry = false;
            do
            {
                Console.WriteLine("Enter your role name (Administrator, Manager, or User)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    roleName = readResult.Trim();
                }
                // roleName = readResult.ToLower().Trim();
                if (roleName.Equals("Administrator") || roleName.Equals("Manager") || roleName.Equals("User"))
                {
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine($"The role name that you entered, \"{roleName}\" is not valid. Enter your role name (Administrator, Manager, or User)");
                }
            } while (validEntry == false);
            Console.WriteLine($"Your input value ({roleName}) has been accepted.");
        }

        /*
            处理字符串数组内容的编码
        */
        public void dealStrs()
        {
            string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
            int strLen = myStrings.Length;
            int periodLocation = 0;
            string myString = "";

            for (int i = 0; i < strLen; i++)
            {
                myString = myStrings[i];
                periodLocation = myString.IndexOf(".");
                string mySentence;

                while(periodLocation != -1)
                {
                    mySentence = myString.Remove(periodLocation);
                    myString = myString.Substring(periodLocation + 1);
                    myString = myString.TrimStart();
                    periodLocation = myString.IndexOf(".");
                    Console.WriteLine(mySentence);
                }
                mySentence = myString.Trim();
                Console.WriteLine(mySentence);
            }
        }
    }
}