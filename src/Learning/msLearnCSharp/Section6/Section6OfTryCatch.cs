using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section6
{
    public class Section6OfTryCatch
    {
        // 练习-捕获特定的异常类型
        /*
        一般来说，代码将 catch 以下异常之一：
            作为基类实例的 System.Exception 异常对象。
            异常对象，它是从基类继承的异常类型的实例。 例如，InvalidCastException 类的一个实例
        */
        // 异常处理的常见方案
        /*
            用户输入：代码处理用户输入时可能发生异常。 例如，当输入值的格式不正确或范围不足时，会发生异常。
            数据处理和计算：当代码执行数据计算或转换时，可能会发生异常。 例如，当代码尝试除以零、强制转换为不受支持的类型或赋值超过范围时，会发生异常。
            文件输入/输出作：当代码从文件中读取或写入文件时，可能会发生异常。 例如，当文件不存在、程序无权访问该文件或文件被另一个进程使用时，会发生异常。
            数据库操作：当代码与数据库交互时，可能会发生异常。 例如，当数据库连接丢失、SQL 语句中发生语法错误或发生约束冲突时，会发生异常。
            网络通信：当代码通过网络通信时，可能会发生异常。 例如，当网络连接丢失、超时或远程服务器返回错误时，会发生异常。
            其他外部资源：当代码与其他外部资源通信时，可能会发生异常。 由于各种原因，Web 服务、REST API 或第三方库可能会引发异常。 例如，由于网络连接问题、格式不正确的数据等，会出现异常。
        */

        // 异常处理通常使用以下一个或多个模式实现：
        /*
            try-catch 模式包含一个 try 块，后跟一个或多个 catch 子句。 每个 catch 块用于指定不同异常的处理程序。
            该 try-finally 模式由一个 try 块组成，然后紧随一个 finally 块。 通常，当控制离开 finally 语句时，try 块的语句将运行。
            该 try-catch-finally 模式实现所有三种类型的异常处理块。 模式中 try-catch-finally 的常见场景是：在 try 块中获取和使用资源，在 catch 块中处理异常情况，并在 finally 块中释放或管理资源。
        */

        // 编译器生成的异常
        /*
            运行时异常及其错误条件的简短列表：
                ArrayTypeMismatchException：当数组无法存储给定元素时引发，因为该元素的实际类型与数组的实际类型不兼容。
                DivideByZeroException：尝试将整数值除以零时引发。
                FormatException：参数格式无效时引发。
                IndexOutOfRangeException：在索引小于零或超出数组边界的情况下，尝试为数组编制索引时引发。
                InvalidCastException：当从基类型到接口或派生类型的显式转换在运行时失败时引发。
                NullReferenceException：尝试引用值为 null 的对象时引发。
                OverflowException：当被选中上下文中的算术运算溢出时引发。
        */
        // 捕获异常
        public void divideTryCatch()
        {
            double float1 = 3000.0;
            double float2 = 0.0;
            int number1 = 3000;
            int number2 = 0;
            try
            {
                Console.WriteLine(float1 / float2);
                Console.WriteLine(number2 / number1);
            }
            catch
            {
                Console.WriteLine("An exception has been caught");
            }
            Console.WriteLine("Exit Program");
        }
        public static void Process1()
        {
            /*
                在此解决方案中，方法 `Process1` 已更新为使用 `try-catch` 模式。 
                在 WriteMessage 代码块中调用 try 方法，从而使 Process1 能够在顶级语句中的 catch 子句捕获异常之前捕获异常。
            */
            try
            {
                WriteMessage();
            }
            catch (DivideByZeroException ex)
            {
                /*
                    注意，由于异常是在 Process1 内部被捕获的，因此顶级语句中的 catch 代码块不会被执行。
                */
                Console.WriteLine("Exception caught in Process1");
                Console.WriteLine($"Exception caught in Process1: {ex.Message}");
            }

        }
        static void WriteMessage()
        {
            double float1 = 3000.0;
            double float2 = 0.0;
            int number1 = 3000;
            int number2 = 0;
            byte smallNumber;

            try
            {
                Console.WriteLine(float1 / float2);
                Console.WriteLine(number1 / number2);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Exception caught in WriteMessage: {ex.Message}");
            }

            checked
            {
                try
                {
                    smallNumber = (byte)number1;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Exception caught in WriteMessage: {ex.Message}");
                }

            }
        }

        public void allException()
        {
            // inputValues is used to store numeric values entered by a user
            string[] inputValues = new string[] { "three", "9999999999", "0", "2" };

            foreach (string inputValue in inputValues)
            {
                int numValue = 0;
                try
                {
                    numValue = int.Parse(inputValue);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid readResult. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too large or too small.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void catchSpecificError()
        {
            checked
            {
                try
                {
                    int num1 = int.MaxValue;
                    int num2 = int.MaxValue;
                    int result = num1 + num2;
                    Console.WriteLine("Result: " + result);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Error: The number is too large to be represented as an integer." + ex.Message);
                }
            }

            try
            {
                string str = null;
                int length = str.Length;
                Console.WriteLine("String Length: " + length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: The reference is null." + ex.Message);
            }

            try
            {
                int[] numbers = new int[5];
                numbers[5] = 10;
                Console.WriteLine("Number at index 5: " + numbers[5]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index out of range." + ex.Message);
            }

            try
            {
                int num3 = 10;
                int num4 = 0;
                int result2 = num3 / num4;
                Console.WriteLine("Result: " + result2);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero." + ex.Message);
            }

            Console.WriteLine("Exiting program.");
        }

    }
}