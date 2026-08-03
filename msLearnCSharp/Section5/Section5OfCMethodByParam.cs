using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section5
{
    public class Section5OfCMethodByParam
    {
        double pi = 3.14159;
        public void PrintCircleArea(int radius)
        {
            double area = pi * (radius * radius);
            Console.WriteLine($"Area = {area}");
        }
        public void PrintCircleCircumference(int radius)
        {
            double circumference = 2 * pi * radius;
            Console.WriteLine($"Circumference = {circumference}");
        }

        // 按值传递和按引用传递的参数
        /*
            在 C# 中，变量可分为两种主要类型：值类型和引用类型。
            值类型，例如int、bool、float和doublechar直接包含值。 
            引用类型（如string、array）和对象（如Random的实例）不会直接存储它们的值。 相反，引用类型存储其值所在的地址。
        */
        /*
            将参数传递给方法时， 值 类型变量的值将复制到方法中。 每个变量都有自己的值副本，因此不会修改原始变量。
            使用引用类型时，值的地址将传递到方法中。 传递给方法的变量引用该地址处的值，因此对该变量的操作会影响被另一个变量引用的值。
        */
        /*
            请务必记住， string 这是一个引用类型，但它是不 可变的。 
            这意味着，一旦为其分配了值，便无法更改该值。 在 C# 中，当方法和运算符用于修改字符串时，返回的结果实际上是一个新的字符串对象。
        */
        // 对按值传递进行测试
        public void Multiply(int a, int b, int c)
        {
            c = a * b;
            Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
        }
        // 对按引用传递进行测试
        public void Clear(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
        public void PrintArray(int[] array)
        {
            foreach (int a in array)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
        }

        // 使用字符串进行测试
        /*
            void F(string msg)
            void F()
            注意区分以上两个对字符串操作方法的区别？
                msg是形参，独立局部变量，在方法内创建新的string变量名、变量副本值等
        */
        public void SetHealth(string status, bool isHealthy)
        {
            status = (isHealthy ? "Healthy" : "Unhealthy");
            Console.WriteLine($"Middle: {status}");
        }

        string msg = "Healthy";

        public void SetHealth2(bool isHealthy)
        {
            msg = (isHealthy ? "Healthy" : "unHealthy");
            Console.WriteLine($"Middle: {msg}");
        }
        public void SetHealth3()
        {
            Console.WriteLine(msg);
        }

        // 练习 - 具有可选参数的方法
        string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
        string[] rsvps = new string[10];
        int count = 0;
        public void RSVP(string name, int partySize, string allergies, bool inviteOnly)
        {
            if (inviteOnly)
            {
                // search guestList before adding rsvp
                bool found = false;
                foreach (string guest in guestList)
                {
                    if (guest.Equals(name))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"Sorry, {name} is not on the guest list");
                    return;
                }
            }

            rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
            count++;
        }

        public void ShowRSVPs()
        {
            Console.WriteLine("\nTotal RSVPs:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(rsvps[i]);
            }
        }

        // 练习 - 完成显示电子邮件地址的挑战
        public void showEmailAdr()
        {
            string[,] corporate =
            {
                {"Robert", "Bavin"}, {"Simon", "Bright"},
                {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
                {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
            };

            string internalDomain = "contoso.com";

            string[,] external =
            {
                {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
                {"Shay", "Lawrence"}, {"Daren", "Valdes"}
            };

            string externalDomain = "hayworth.com";

            for (int i = 0; i < corporate.GetLength(0); i++)
            {
                // display internal email addresses
                // string firstName = corporate[i,0].Substring(0,2);
                // string lastName = corporate[i,1];
                // string internalName = firstName + lastName;
                // internalName = internalName.ToLower();
                // Console.WriteLine($"{internalName}@{internalDomain}");
                disPlayEmail(first: corporate[i,0],last: corporate[i,1]);

            }

            for (int i = 0; i < external.GetLength(0); i++)
            {
                // display external email addresses
                // string firstName = external[i,0].Substring(0,2);
                // string lastName = external[i,1];
                // string externalName = firstName + lastName;
                // externalName = externalName.ToLower();
                // Console.WriteLine($"{externalName}@{externalDomain}");
                disPlayEmail(first:external[i,0],last: external[i,1],domain: externalDomain);
            }
        }
        public void disPlayEmail(string first, string last, string domain = "contoso.com")
        {
            // string firstName = first.Substring(0,2);
            // string lastName = last;
            // string preSiff = firstName + lastName;
            // preSiff = preSiff.ToLower();
            string email = first.Substring(0,2) + last;
            email = email.ToLower();
            Console.WriteLine($"{email}@{domain}");
        }


    }
}