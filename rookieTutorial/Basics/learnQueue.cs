using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.Basics
{
    public class learnQueue
    {
        // Queue<T> 队列，先进先出，在System.Collections.Generic命名空间
        /*
            方法	            作用
            Enqueue(T item)	    添加元素到队列尾部
            Dequeue()	        取出并删除队首元素，队列为空会抛异常
            Peek()	            获取队首元素，不移除，空队列抛异常
            Count	            属性，获取队列里面元素个数
            Contains(T item)	判断队列是否包含某个元素
            Clear()	            清空队列所有元素
            ToArray()	        把队列转为数组
        */
        public void optQueueMethod()
        {
            Queue<int> queue = new Queue<int>();
            // 入队，向队尾添加 Enqueue
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine($"队列数量元素：{queue.Count}");
            // 看队首，不取走
            int first = queue.Peek();
            Console.WriteLine($"队首元素：{first}");
            // 遍历队列
            Console.WriteLine("遍历队列");
            foreach (var num in queue)
            {
                Console.Write(num + " ");
            }
            // 出队，取出并删除队首
            int val1 = queue.Dequeue();
            Console.WriteLine($"取出：{val1}");
            Console.WriteLine($"取出后数量：{queue.Count}");
            // 判断是否包含
            bool has20 = queue.Contains(20);
            Console.WriteLine($"是否包含20：{has20}");
            // 全部出队，直到队列为空
            Console.WriteLine("循环全部出队");
            while(queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue() + " ");
            }
            Console.WriteLine();
            queue.Clear();
            Console.WriteLine($"清空后数量：{queue.Count}");
        }
    }
}