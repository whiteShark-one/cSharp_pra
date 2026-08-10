using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    public abstract class School
    {
        public int Id{get;set;}
        public string Name{get;set;}

        // #1 重写toString()方法，输出JSON格式
        // public override string ToString()
        // {
        //     // return base.ToString();
        //     return JsonSerializer.Serialize(this,new JsonSerializerOptions{
        //         Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //         WriteIndented = true
        //     });
        // }

        // #2 重写toString()方法，输出JSON格式，并检查当前对象是否带有标签
        public override string ToString()
        {
            // return base.ToString();
            // var type = this.GetType();
            var type = GetType();
            
            // #1 自己的写法
            /* 
                运行期间，使用type.GetCustomAttribute<>()获取类上贴的标签JsonSerializerAttribute
                如果不为空，返回JSON
            */
            // var hasJsonSerializableAttribute = type.GetCustomAttribute<JsonSerializerAttribute>();
            // if (hasJsonSerializableAttribute != null)
            
            // #2 参考的写法
            var hasJsonSerializableAttribute = type.IsDefined(typeof(JsonSerializerAttribute),false);
            if (hasJsonSerializableAttribute)
            {
                return JsonSerializer.Serialize(this,new JsonSerializerOptions{
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            });
            }
            return base.ToString();  
        }
    }
}