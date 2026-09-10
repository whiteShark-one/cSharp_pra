using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rookieTutorial.AdvancedFeature;

namespace rookieTutorial
{
    public class ProcessMonitor
    {
         // #6 订阅者监视事件状态，如果事件触发，订阅者应收到通知
        //  public void onProcessCreate(int processId)
        // {
        //     Console.WriteLine($"[Monitor]: Process {processId} has been created.");
        // }
        public void onProcessCreate(object sender,EventArgs e)
        {
            if (e is ProcessEventArgs arg)
            {
                Console.WriteLine($"[Monitor]: Process {arg.ProcessId} has been created.");
            }
        }
    }
}