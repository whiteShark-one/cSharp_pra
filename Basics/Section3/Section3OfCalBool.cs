using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics.Section3
{
    public class Section3OfCalBool
    {
        /*
            使用条件运算符
        */
        public void useConOpt()
        {
            int saleAmount = 1001;
            int discount = saleAmount > 1000 ? 100 : 50;
            // Console.WriteLine($"Discount : {discount}");
            Console.WriteLine($"Discount : {(saleAmount > 1000 ? 100 : 50)}");
        }
        /*
            使用布尔表达式以显示硬币反转结果
        */
        public void reverseCoins()
        {
            Random random = new Random();
            int roll = random.Next(2);
            Console.WriteLine($"The result of coin is : {(roll == 0 ? "heads" : "tails")}");
        }
        /*
            使用布尔表达式以指定访问权限
        */
        public void accessPer()
        {
            string permission = "Admin|Manager";
            int level = 55;
            string message = "";
            if (permission.Contains("Admin"))
            {
                if (level > 55)
                {
                    message = "Welcome, Super Admin user.";
                }
                else
                {
                    message = "Welcome, Admin user.";
                }
            }
            else if (permission.Contains("Manager"))
            {
                if (level >= 20)
                {
                    message = "Contact an Admin for access.";
                }
                else
                {
                    message = "You do not have sufficient privileges.";
                }
            }
            else
            {
                message = "You do not have sufficient privileges";
            }
            // message = (permission.Contains("Admin") || permission.Contains("Manager")) ? (permission.Contains("Admin") ? (level > 55 ? "Welcome, Super Admin user." : "Welcome, Admin user.") : (level >= 20 ? "Contact an Admin for access." : "You do not have sufficient privileges.")) : "You do not have sufficient privileges.";
            Console.WriteLine(message);
        }
    }
}