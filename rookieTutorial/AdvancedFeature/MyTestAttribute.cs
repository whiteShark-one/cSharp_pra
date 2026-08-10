using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    // 自定义测试标签
    [AttributeUsage(AttributeTargets.Method)]
    public class MyTestAttribute : Attribute
    {
        
    }

    class TestDemo
    {
        [MyTest]
        public void TestA()
        {
            Console.WriteLine("执行测试A");
        }
        [MyTest]
        public void TestB()
        {
            Console.WriteLine("执行测试B");
        }
        // 没有打标签不会被执行
        public void TestC()
        {
            Console.WriteLine("执行测试C");
        }
    }
}