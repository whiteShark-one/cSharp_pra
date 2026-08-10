using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    // [JsonSerializer]
    public class Teacher : School
    {
        public string? Level{get;set;} = string.Empty;
    }
}