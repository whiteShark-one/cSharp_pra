using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics.Section2
{
    public class Section2OfDecisionLogic
    {
        // 判断三个随机数是否相等
        public void isRandomEqual()
        {
            Random dice = new Random();
            int roll1 = dice.Next(1, 7);
            int roll2 = dice.Next(1, 7);
            int roll3 = dice.Next(1, 7);
            roll1 = 6;
            roll2 = 6;
            roll3 = 6;
            int total = roll1 + roll2 + roll3;
            Console.WriteLine($"Dice total : {total} = {roll1} + {roll2} + {roll3}");
            // if、else、
            if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
            {
                if ((roll1 == roll2) && (roll2 == roll3))
                {
                    Console.WriteLine("You rolled triples! +6 bonus to total!");
                    total += 6;
                }
                else
                {
                    Console.WriteLine("You rolled doubles! +2 bonus to total!");
                    total += 2;
                }
            }

            if (total >= 16)
            {
                Console.WriteLine("You win a car");
            }
            else if (total >= 10)
            {
                Console.WriteLine("you win a new laptop");
            }
            else if (total >= 7)
            {
                Console.WriteLine("you win a trip for two");
            }
            else
            {
                Console.WriteLine("You win a kitten!");
            }
            string message = "The quick brown fox jumps over the lazy dog.";
            bool res = message.Contains("dog");
            Console.WriteLine(res);
            if (message.Contains("fox"))
            {
                Console.WriteLine("What does the fox say?");
            }
        }

        // 续订提醒
        public void remindRent()
        {
            Random random = new Random();
            int daysUntilExpiration = random.Next(12);
            int discountPercentage = 0;

            // Your code goes here
            if (daysUntilExpiration == 0)
            {
                Console.WriteLine("Your subscription has expired.");
            }
            else if (daysUntilExpiration == 1)
            {
                discountPercentage = 20;
                Console.WriteLine($"Your subscription expires within a day!");
            }
            else if (daysUntilExpiration <= 5)
            {
                discountPercentage = 10;
                Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
            }
            else if (daysUntilExpiration <= 10)
            {
                Console.WriteLine("Your subscription will expire soon. Renew now!");
            }
            
            if (discountPercentage > 0)
            {
                Console.WriteLine($"Renew now and save {discountPercentage}%!.");
            }


        }
    }
}