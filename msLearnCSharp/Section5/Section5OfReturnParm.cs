using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section5
{

    public class Section5OfReturnParm
    {
        public void initalInput()
        {
            double total = 0;
            double minimumSpend = 30.00;

            double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
            double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

            for (int i = 0; i < items.Length; i++)
            {
                total += GetDiscountedPrice(i, items, discounts);
            }

            total -= TotalMeetsMinimum(total, minimumSpend) ? 5.00 : 0.00;

            Console.WriteLine($"Total: ${FormatDecimal(total)}");

        }
        public double GetDiscountedPrice(int itemIndex, double[] items, double[] discounts)
        {
            // Calculate the discounted price of the item
            double result = items[itemIndex] * (1 - discounts[itemIndex]);
            return result;
        }
        public bool TotalMeetsMinimum(double total, double minimumSpend)
        {
            // Check if the total meets the minimum
            return total >= minimumSpend;
        }
        public string FormatDecimal(double input)
        {
            // Format the double so only 2 decimal places are displayed
            return input.ToString().Substring(0, 5);
        }

        // 从方法中返回数字
        public int UsdToVnd(double usd)
        {
            int rate = 23500;
            /*
                如果省略(int)返回，编译器会报错
                只有在转换不会导致数据丢失的情况下，隐式强制转换才可用
            */
            // return rate *usd;
            return (int)(rate * usd);
        }
        // 创建返回双精度的方法
        public double VndToUsd(int vnd)
        {
            /*
                如果将 rate 设置为 int 而不是 double，你会注意到编译器不会显示任何错误。 
                发生这种情况的原因是 vnd / rate 的值隐式强制转换为方法签名中指定的 double 数据类型。
            */
            int rate = 23500;
            return vnd / rate;
        }

        public string ReverseSentence(string input)
        {
            string result = "";
            string[] words = input.Split(" ");
            foreach (string word in words)
            {
                result += ReverseWord(word) + " ";
            }
            return result.Trim();
        }

        // 练习-从方法中返回字符串
        public string ReverseWord(string word)
        {
            string result = "";
            // 创建字符数组
            char[] arrayStr = word.ToCharArray();
            int len = arrayStr.Length;
            int left = 0, right = len - 1;
            while (left < right)
            {
                char temp = arrayStr[left];
                arrayStr[left] = arrayStr[right];
                arrayStr[right] = temp;
                left++;
                right--;
            }
            result = new string(arrayStr);
            return result;
        }

        // 练习-从方法中返回数组
        // 查找硬币的位置
        public int[] TwoCoins(int[] coins, int target)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = i + 1; j < coins.Length; j++)
                {
                    if (coins[i] + coins[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[0];
        }
        // 找到多对用于找零的硬币
        public int[,] DoubleTwoCoins(int[] coins, int target)
        {
            int[,] result = { { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 }, { -1, -1 } };
            int count = 0;
            for (int curr = 0; curr < coins.Length; curr++)
            {
                for (int next = curr + 1; next < coins.Length; next++)
                {
                    if (coins[curr] + coins[next] == target)
                    {
                        result[count, 0] = curr;
                        result[count, 1] = next;
                        count++;
                    }
                    if (count == result.GetLength(0))
                    {
                        return result;
                    }
                }
            }
            return (count == 0) ? new int[0, 0] : result;
        }

        // 骰子
        Random random = new Random();
        public void PlayGame()
        {
            var play = false;
            string? readResult;
            string isContinue = "";

            // while (play)
            // {
            //     var target = random.Next(1, 6);
            //     var roll = random.Next(1, 6);

            //     Console.WriteLine($"Roll a number greater than {target} to win!");
            //     Console.WriteLine($"You rolled a {roll}");
            //     Console.WriteLine(WinOrLose(target, roll));
            //     Console.WriteLine("\nPlay again? (Y/N)");

            //     play = ShouldPlay();
            // }
            do
            {
                var target = random.Next(1, 6);
                var roll = random.Next(1, 6);

                Console.WriteLine("Would you like to play? (Y/N)");
                readResult = Console.ReadLine();
                if (readResult != null && readResult != "")
                {
                    isContinue = readResult.ToUpper().Trim();
                }
                
                play = isContinue.Equals("Y");
                // 如果不玩，直接退出
                if (!play) break;

                Console.WriteLine($"Roll a number greater than {target} to win!");
                Console.WriteLine($"You rolled a {roll}");
                Console.WriteLine(WinOrLose(target, roll));
                Console.WriteLine("\nPlay again? (Y/N)");
            } while (play);
        }

        // public bool ShouldPlay()
        // {
        //     return isContinue.Equals("Y");
        // }
        string WinOrLose(int target, int roll)
        {
            string res = "";
            if (roll > target)
            {
                res = "You win!";
            }
            else
            {
                res = "You lose!";
            }
            return res;
        }
    }
}