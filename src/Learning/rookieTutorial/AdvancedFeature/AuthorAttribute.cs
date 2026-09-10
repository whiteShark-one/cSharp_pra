using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] //限定可以贴在类、方法上
    public class AuthorAttribute : Attribute
    {
        public string Name{get;}
        public string Version{get;set;}

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }
}