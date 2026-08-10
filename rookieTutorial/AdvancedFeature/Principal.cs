using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    [JsonSerializer]
    public class Principal : School
    {
        public string? Office{get;set;} = string.Empty;
    }
}