using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    class ProcessEventArgs : EventArgs
    {
        public int ProcessId
        {
            get;
            set;
        }
        public ProcessEventArgs(int processId)
        {
            ProcessId = processId;
        }

    }
    public class ProcessManager
    {
        /*
            事件event为对象之间提供了一种通信方式，它们基于发布者-订阅者模型：当特定事情发生时，发布者会通知其他订阅者
            事件是基于委托的封装
            应该使用标准事件模型而非自定义事件
        */
        /*
            观察者模式：发布者发布事件，另一群感兴趣的订阅者订阅这个事件，并在事件发生的时候接到通知并做出响应
            订阅机制：基于委托的组播挂载方法 += 实现订阅者的方法订阅，-= 实现取消订阅 （基于委托实现）
        */
        // 发布者：进程管理者用于发布一个进程，如果进程发生了变化，需要通知所有订阅它的人
        // #1 定义一个委托，用于传递进程ID
        // public delegate void ProcessCreateHandler(int processId);
        // #2 基于委托声明一个事件（对于委托的封装）
        // public event ProcessCreateHandler? processCreated;
        public event EventHandler processCreated; // 更改为推荐的EventHandler类型
        // #3 创建一个进程
        public void createProcess(int processId)
        {
            Console.WriteLine($"[Manager]: {processId}");
            // #4 创建进程后，通知其他订阅者 -> 触发事件
            // 空条件运算符 
            // processCreated?.Invoke(processId);   // ? 先判断是否有订阅者，为空直接返回，不为空执行Invoke
            // processCreateHandler?.Invoke(this, null);
            processCreated?.Invoke(this,new ProcessEventArgs(3303));
        }
    }
}