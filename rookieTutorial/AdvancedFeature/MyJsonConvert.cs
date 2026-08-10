using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rookieTutorial.AdvancedFeature
{
    public class MyJsonConvert
    {
        // public static string SerializeObject(Cow cow)
        // {
        //     var sb = new StringBuilder();

        //     sb.Append('{');
        //     sb.Append("\r\n");

        //     sb.Append($"{new string(' ',4)}Id:{cow.Id}");
        //     sb.Append("\r\n");
        //     sb.Append($"{new string(' ',4)}Name:{cow.Name}");
        //     sb.Append("\r\n");
        //     sb.Append($"{new string(' ',4)}Age:{cow.Age}");
        //     sb.Append("\r\n");
        //     sb.Append($"{new string(' ',4)}Gender:{cow.Gender}");
        //     sb.Append("\r\n");
        //     sb.Append($"{new string(' ',4)}Class:{cow.Class}");
        //     sb.Append("\r\n");

        //     sb.Append('{');

        //     return sb.ToString();
        // }

        public static string SerializeObject(Object o)
        {
            var sb = new StringBuilder();

            sb.Append('{');
            sb.Append("\r\n");

            // 通过反射获取类型信息
            // 也就是获取对象o的所有属性
            var properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(o,null);

                sb.Append($"{new string(' ',4)}{propertyName}: {propertyValue}");
                sb.Append("\r\n");
            }

            sb.Append('{');

            return sb.ToString();

        }
    }
}