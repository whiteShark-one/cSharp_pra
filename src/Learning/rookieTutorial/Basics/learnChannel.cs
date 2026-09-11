using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace rookieTutorial.Basics
{
    public class learnChannel
    {
        /*
        # 逐轮时序拆解（一轮循环 i=0 举例）
            1. 进入循环，调用 `writer.WriteAsync(0)`
            - 尝试往 Channel 写数据：
                - 如果通道未满：写入成功，返回一个已完成 Task。`await`发现任务已经完成，不释放线程，直接继续往下跑。
                - 如果通道满了：`WriteAsync` 返回未完成 Task → **触发 await，当前线程归还线程池，ProduceAsync 暂停在这里**。等消费者读取、通道腾出空位后，再调度线程回来继续。
            2. `await writer.WriteAsync(i)` 完成后：执行`Console.WriteLine`（同步代码，占用线程短暂执行）
            3. 执行 `await Task.Delay(100)`
            - 启动一个 100ms 的计时器，返回未完成 Task。
            - 当前线程释放，还给线程池！
            - 100ms 计时到，任务完成；.NET 从线程池取出一条可用线程，回到`await Task.Delay`的下一行，进入下一轮 for 循环。
        > 
        > 重点：等待 Delay 的这 100ms 期间，没有线程被占用！线程可以去处理别的任务。
        */
        public static async Task ProduceAsync(ChannelWriter<int> writer)
        {
            for (int i = 0; i < 10; i++)
            {
                await writer.WriteAsync(i);
                Console.WriteLine($"[生产] 写入: {i}");
                await Task.Delay(100); //   模拟生产耗时
            }
            Console.WriteLine("[生产] 生产完毕");
        }
        public static async Task ConsumeAsync(ChannelReader<int> reader)
        {
            // 方式1：使用 WaitToReadAsync + TryRead 循环
            /*
                API讲解
                1. `await reader.WaitToReadAsync()`
                异步等待：通道里有数据可读，或者通道被 Complete 关闭。
                - 有数据 → 返回 `true`，进入内层循环去读；
                - 通道写完并 Complete、数据全部读完 → 返回`false`，跳出外层 while，消费结束。
                - 等待期间`await`释放线程，不阻塞。
                2. `reader.TryRead(out int item)`
                - 同步非阻塞读取！ 立刻尝试拿一条，拿到返回 true；没数据直接返回 false，不会等待。

                > 
                > 内层 while 一次性把当前通道里堆积的所有数据一次性循环读完。
                > 这是 Channel 推荐写法：WaitToRead 等 “有数据信号”，然后 TryRead 批量捞取。
            */
            /*
                > 生产者：每 100ms 生产 1 个；消费者处理 1 个要 200ms，消费慢，队列会堆积，触发背压。
                > 通道容量 = 3。

                1. t=0ms
                生产者写入 i=0；队列：[0]`WaitToReadAsync` 检测到有数据 → true，进入内层 TryRead
                TryRead 拿到 0，打印，`await Task.Delay(200)` → 释放线程，等待 200ms
                2. t=100ms
                生产者写入 i=1；队列：[1]
                消费者还在 Delay 等待中，不处理
                3. t=200ms
                消费者 Delay 完成，回到代码，内层循环再次 TryRead → 拿到 1，打印，再 Delay200ms。队列空。
                4. t=200ms 生产者写入 i=2；队列 [2]
                5. t=300ms 生产者写入 i=3；队列 [2,3]
                6. t=400ms
                消费者 Delay 结束，TryRead 拿到 2，打印，Delay200ms
                生产者尝试写入 i=4 → 队列已经塞满 3 个 (2,3,4)，`WriteAsync` await 挂起生产者（背压！生产者暂停不再生产）
                > 
                > 重点：生产者被卡住，不再生成新数据，直到消费者取走元素腾出通道空位。
                7. t=600ms
                消费者处理完 2，TryRead 拿到 3，打印，Delay200ms，队列腾出位置 → 被暂停的生产者恢复，继续生产
            */
            // while (await reader.WaitToReadAsync())
            // {
            //     while (reader.TryRead(out int item))
            //     {
            //         Console.WriteLine($"[消费] 读取: {item}");
            //         await Task.Delay(200); // 模拟消费耗时（比生产慢）
            //     }
            // }

            // 方式2：使用 await foreach 遍历（推荐）
            await foreach (int item in reader.ReadAllAsync()) 
            {
                Console.WriteLine($"[消费] 读取: {item}");
                await Task.Delay(200);
            }
            Console.WriteLine("[消费] 通道已关闭，消费结束");
        }
    }
}