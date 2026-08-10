using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    [AttributeUsage(AttributeTargets.Enum,Inherited =false)]
    public class FlagsAttribute : Attribute
    {
        public FlagsAttribute(){}
    }
}