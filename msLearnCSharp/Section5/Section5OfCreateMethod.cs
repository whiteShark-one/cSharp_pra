using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section5
{
    public class Section5OfCreateMethod
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public void DisplayRandomNumbers()
        {
            Random random = new Random();
        }

        // 标识重复的代码
        public void markReCode()
        {
            int[] times = { 800, 1200, 1600, 2000 };
            int diff = 0;

            Console.WriteLine("Enter current GMT");
            int currentGMT = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Current Medicine Schedule:");
            DisplayTimes(times);
            /* Format and display medicine times */
            // foreach (int val in times)
            // {
            //     string time = val.ToString();
            //     int len = time.Length;

            //     if (len >= 3)
            //     {
            //         time = time.Insert(len - 2, ":");
            //     }
            //     else if (len == 2)
            //     {
            //         time = time.Insert(0, "0:");
            //     }
            //     else
            //     {
            //         time = time.Insert(0, "0:0");
            //     }

            //     Console.Write($"{time} ");
            // }


            Console.WriteLine();

            Console.WriteLine("Enter new GMT");
            int newGMT = Convert.ToInt32(Console.ReadLine());

            if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
            {
                Console.WriteLine("Invalid GMT");
            }
            else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
            {
                diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));

                /* Adjust the times by adding the difference, keeping the value within 24 hours */
                // for (int i = 0; i < times.Length; i++)
                // {
                //     times[i] = ((times[i] + diff)) % 2400;
                // }
                AdjustTimes(times, diff);
            }
            else
            {
                diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));

                /* Adjust the times by adding the difference, keeping the value within 24 hours */
                // for (int i = 0; i < times.Length; i++)
                // {
                //     times[i] = ((times[i] + diff)) % 2400;
                // }
                AdjustTimes(times, diff);
            }

            Console.WriteLine("New Medicine Schedule:");
            DisplayTimes(times);
            /* Format and display medicine times */
            // foreach (int val in times)
            // {
            //     string time = val.ToString();
            //     int len = time.Length;

            //     if (len >= 3)
            //     {
            //         time = time.Insert(len - 2, ":");
            //     }
            //     else if (len == 2)
            //     {
            //         time = time.Insert(0, "0:");
            //     }
            //     else
            //     {
            //         time = time.Insert(0, "0:0");
            //     }

            //     Console.Write($"{time} ");
            // }
            Console.WriteLine();
        }

        // 创建执行重复的任务
        void DisplayTimes(int[] times)
        {
            /* Format and display medicine times */
            foreach (int val in times)
            {
                string time = val.ToString();
                int len = time.Length;

                if (len >= 3)
                {
                    time = time.Insert(len - 2, ":");
                }
                else if (len == 2)
                {
                    time = time.Insert(0, "0:");
                }
                else
                {
                    time = time.Insert(0, "0:0");
                }

                Console.Write($"{time} ");
            }

            Console.WriteLine();
        }

        void AdjustTimes(int[] times, int diff)
        {
            /* Adjust the times by adding the difference, keeping the value within 24 hours */
            for (int i = 0; i < times.Length; i++)
            {
                times[i] = ((times[i] + diff)) % 2400;
            }
        }

        // 验证ip值是否有效
        public void isIPv4()
        {
            string str = "107.315.1.5";
            if (ValidateLength(str) && ValidateZeroes(str) && ValidateRange(str))
            {
                Console.WriteLine($"ip is a valid IPv4 address");
            }
            else
            {
                Console.WriteLine($"ip is an invalid IPv4 address");
            }
        }
        bool ValidateLength(string ipv4Input)
        {
            string[] address = ipv4Input.Split(".");
            bool validLength = address.Length == 4;
            return validLength;
        }
        bool ValidateZeroes(string ipv4Input)
        {
            string[] address = ipv4Input.Split(".");
            bool validZeroes = true;
            foreach (string number in address)
            {
                if (number.Length > 1 && number.StartsWith("0"))
                {
                    validZeroes = false;
                }
            }
            return validZeroes;
        }
        bool ValidateRange(string ipv4Input)
        {
            string[] address = ipv4Input.Split(".", StringSplitOptions.RemoveEmptyEntries);
            bool validRange = true;
            foreach (string number in address)
            {
                int value = int.Parse(number);
                if (value < 0 || value > 255)
                {
                    validRange = false;
                }
            }
            return validRange;
        }

        // 练习 - 完成创建可重用方法的挑战
        public void tellFortune()
        {
            Random random = new Random();
            int luck = random.Next(100);

            string[] text = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
            string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
            string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
            string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };

            luckRandom(luck, text, good, bad, neutral);
        }
        void luckRandom(int luck, string[] text, string[] good, string[] bad, string[] neutral)
        {
            Console.WriteLine("A fortune teller whispers the following words:");
            string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{text[i]} {fortune[i]} ");
            }
        }

    }
}