using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{   
    [AttributeUsage(AttributeTargets.Class)]
    public class RemarkAttribute : Attribute
    {
        // C#自动后台编译私有后备字段 info
        // // private readonly string info;
        // 自动属性
        // public string Info { get; }
        // public RemarkAttribute(string info) => Info = info;

        // 手写属性+get/set逻辑
        private string info;
        public string Info{
            get{return info;}
            set{info = value;}
        }
        public RemarkAttribute(){}
        public RemarkAttribute(string info)
        {
            this.info = info;
        }
    }
}