using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    class Unit1OfTextAndVariables
    {
        // 成员变量
        public string _firstname;
        char _userOption;
        int _gameScore;
        decimal _particlePerMillion;
        bool _processedCustomer;
        public Unit1OfTextAndVariables(string firstname,char userOption,int gameScore,decimal particlePerMillion,bool processedCustomer)
        {
            _firstname = firstname;
            _userOption = userOption;
            _gameScore = gameScore;
            _particlePerMillion = particlePerMillion;
            _processedCustomer = processedCustomer;
        }

        // 成员函数

        // 打印成员变量的值
        public void PrintPro()
        {
            // 打印_firstname
            Console.WriteLine("打印_firstname：{0}", _firstname);
            // 打印_userOption
            Console.WriteLine("打印_userOption：{0}", _userOption);
        }

        // 打印文本值
        public void PrintText()
        {
            // 打印字符文本
            Console.WriteLine("打印字符文本：{0}",'c');
            // 打印整数文本
            Console.WriteLine("打印整数文本：{0}",12);
            // 打印浮点文本，要加字母f
            Console.WriteLine("打印浮点文本：{0},{1}",0.25f,2.625f);
            // 打印十进制文本，要加字母m
            Console.WriteLine("打印十进制文本：{0}",12.39618m);
            // 打印布尔文本
            Console.WriteLine("打印布尔文本：{0}",true);
        }

        public void PrintTextAndVar()
        {
            string var1 = "鲍勃Bob";
            int var2 = 3;
            float var3 = 34.4f; 
            decimal var4 = 34.53m;
            Console.WriteLine("Hello, {0}! You have {1} messages in your inbox. The temperature is {2} celsius {3}.", var1,var2,var3,var4);
        }
    }
}