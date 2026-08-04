using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section6
{
    public class Section6OfCreateErrorObject
    {
        // 创建异常对象
        /*
            ArgumentException 或 ArgumentNullException：当使用无效参数值或 null 引用调用方法或构造函数时，请使用这些异常类型。
            InvalidOperationException：当方法的作条件不支持成功完成特定方法调用时，请使用此异常类型。
            NotSupportedException：在操作或功能不受支持时使用此异常类型。
            IOException：当输入/输出作失败时，请使用此异常类型。
            FormatException：当字符串或数据的格式不正确时，请使用此异常类型。
        */
        /*
            关键字 new 用于创建异常的实例。 例如，可以创建异常类型的实例 ArgumentException ，如下所示：
            ArgumentException invalidArgumentException = new ArgumentException();
        */
        // 配置和引发自定义异常
        /*
            引发异常对象的过程涉及创建异常派生类的实例，可以选择配置异常的属性，然后使用关键字引发对象 throw 。
            可以通过配置异常对象的属性来提供应用程序特定信息，例如：
            以下代码创建一个使用自定义invalidArgumentException属性命名Message的异常对象，然后引发异常：
            ArgumentException invalidArgumentException = new ArgumentException("ArgumentException: The 'GraphData' method received data outside the expected range.");
            throw invalidArgumentException;
        */
        /*
            注意：异常的 Message 属性为只读。 因此，在实例化对象时必须设置自定义 Message 属性。
            自定义异常对象时，请务必提供明确的错误消息来描述问题以及如何解决此问题。 还可以包含其他信息，例如堆栈跟踪和错误代码，以帮助用户更正问题。
        */
        /*
            还可以直接在语句中创建 throw 异常对象。 例如：
            throw new FormatException("FormatException: Calculations in process XYZ have been cancelled due to invalid data format.");
        */

        // 何时引发异常
        public void indictError()
        {
            try
            {
                OperatingProcedure1();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting application.");
            }
        }
        public void OperatingProcedure1()
        {
            string[][] userEnteredValues = new string[][]
                                            {
                                                    new string[] { "1", "two", "3"},
                                                    new string[] { "0", "1", "2"}
                                            };

            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    BusinessProcess1(userEntries);
                }
                catch (Exception ex)
                {
                    if (ex.StackTrace.Contains("BusinessProcess1"))
                    {
                        if (ex is FormatException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Corrective action taken in OperatingProcedure1");
                        }
                        else if (ex is DivideByZeroException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Partial correction in OperatingProcedure1 - further action required");

                            // re-throw the original exception
                            throw;
                        }
                        else
                        {
                            // create a new exception object that wraps the original exception
                            throw new ApplicationException("An error occurred - ", ex);
                        }
                    }
                }
            }
        }
        static void BusinessProcess1(string[] userEntries)
        {
            int valueEntered;

            foreach (string userValue in userEntries)
            {
                try
                {
                    valueEntered = int.Parse(userValue);

                    // completes required calculations based on userValue
                    // ...
                    checked
                    {
                        int calculatedValue = 4 / valueEntered;
                    }
                }
                catch (FormatException)
                {
                    FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
                    throw invalidFormatException;
                }
                catch (DivideByZeroException)
                {
                    DivideByZeroException unexpectedDivideByZeroException = new DivideByZeroException("DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero");
                    throw unexpectedDivideByZeroException;
                }
            }
        }

        // 练习-创建并引发异常
        public void induceErrorPra2()
        {
            // Prompt the user for the lower and upper bounds
            Console.Write("Enter the lower bound: ");
            int lowerBound = int.Parse(Console.ReadLine());

            Console.Write("Enter the upper bound: ");
            int upperBound = int.Parse(Console.ReadLine());

            decimal averageValue = 0;
            bool exit = false;
            do
            {
                try
                {
                    // Calculate the sum of the even numbers between the bounds
                    averageValue = AverageOfEvenNumbers(lowerBound, upperBound);
                    // Display the value returned by AverageOfEvenNumbers in the console
                    Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");
                    // 成功执行AverageOfEvenNumbers()，退出循环
                    exit = true;
                }
                catch (ArgumentException ex)
                {
                    /*
                    若要处理此异常，代码需要执行以下动作：
                        向用户解释问题。
                        获取新值 upperBound。
                        使用新upperBound调用 AverageOfEvenNumbers 。
                        catch如果提供的新upperBound项仍然小于或等于lowerBound，请继续执行异常。
                    */
                    // 继续执行 catch 异常需要循环。 由于至少要调用 AverageOfEvenNumbers 一次方法，因此应使用循环 do 。
                    Console.WriteLine("An error has occurred.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"The upper bound must be greater than {lowerBound}");
                    Console.Write($"Enter a new upper bound: ");
                    // upperBound = int.Parse(Console.ReadLine());
                    string? userResponse = Console.ReadLine();
                    if (userResponse.ToLower().Contains("exit"))
                    {
                        exit = true;
                    }
                    else
                    {
                        upperBound = int.Parse(userResponse);
                    }
                }
            } while (exit == false);
            // Wait for user input
            Console.ReadLine();
        }
        static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
        {
            // 创建、引发上下限判断异常
            if (lowerBound >= upperBound)
            {
                /*
                    如果可能，应在可以处理异常的调用堆栈级别捕获异常。 
                    在此示例应用程序中，方法的参数 AverageOfEvenNumbers 可以在调用方法（顶级语句）中管理。
                */
                throw new ArgumentException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than lower bound.");
            }
            int sum = 0;
            int count = 0;
            decimal average = 0;

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                    count++;
                }
            }

            average = (decimal)sum / count;

            return average;
        }

        // 练习 - 完成创建和引发异常的挑战活动
        public void unnormalError()
        {
            string[][] userEnteredValues = new string[][]
                                            {
                                                        new string[] { "1", "2", "3"},
                                                        new string[] { "1", "two", "3"},
                                                        new string[] { "0", "1", "2"}
                                            };

            try
            {
                Workflow1(userEnteredValues);
                Console.WriteLine("'Workflow1' completed successfully.");

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("An error occurred during 'Workflow1'.");
                Console.WriteLine("Invalid data. User input values must be non-zero values.");
            }
        }
        static void Workflow1(string[][] userEnteredValues)
        {
            // string operationStatusMessage = "good";
            // string processStatusMessage = "";

            // foreach (string[] userEntries in userEnteredValues)
            // {
            //     processStatusMessage = Process1(userEntries);

            //     if (processStatusMessage == "process complete")
            //     {
            //         Console.WriteLine("'Process1' completed successfully.");
            //         Console.WriteLine();
            //     }
            //     else
            //     {
            //         Console.WriteLine("'Process1' encountered an issue, process aborted.");
            //         Console.WriteLine(processStatusMessage);
            //         Console.WriteLine();
            //         operationStatusMessage = processStatusMessage;
            //     }
            // }

            // if (operationStatusMessage == "good")
            // {
            //     operationStatusMessage = "operating procedure complete";
            // }

            // return operationStatusMessage;

            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    Process1(userEntries);
                    Console.WriteLine("'Process1' completed successfully.");
                    Console.WriteLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("'Process1' encountered an issue, process aborted.");
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine();
                }
            }
        }
        static void Process1(String[] userEntries)
        {
            foreach (string userValue in userEntries)
            {
                try
                {
                    int valueEntered = int.Parse(userValue);
                    checked
                    {
                        int calculatedValue = 4 / valueEntered;
                    }
                }
                catch (FormatException)
                {
                    FormatException invalidFormatException = new FormatException("Invalid data. User input values must be valid integers.");
                    throw invalidFormatException;
                }
                catch (DivideByZeroException)
                {
                    DivideByZeroException unexceptedDivideByZeroException = new DivideByZeroException("Invalid data. User input values must be valid integers.");
                    throw unexceptedDivideByZeroException;
                }
            }
            // string processStatus = "clean";
            // string returnMessage = "";
            // int valueEntered;
            // foreach (string userValue in userEntries)
            // {
            //     bool integerFormat = int.TryParse(userValue, out valueEntered);

            //     if (integerFormat == true)
            //     {
            //         if (valueEntered != 0)
            //         {
            //             checked
            //             {
            //                 int calculatedValue = 4 / valueEntered;
            //             }
            //         }
            //         else
            //         {
            //             returnMessage = "Invalid data. User input values must be non-zero values.";
            //             processStatus = "error";
            //         }
            //     }
            //     else
            //     {
            //         returnMessage = "Invalid data. User input values must be valid integers.";
            //         processStatus = "error";
            //     }
            // }

            // if (processStatus == "clean")
            // {
            //     returnMessage = "process complete";
            // }
        }
    }
}