using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace rookieTutorial.AdvancedFeature
{
    // 反射 和 特性
    /*
    一般是使用new 和 . 
    反射可以获取任何一种类型的所有信息，包括它的所有属性
        # 反射是C#中内置的一些类，比如Assembly、PropertyInfo、MethodInfo、Type等
        # 可以使用这些类用于：
            - 查找类型：在运行时找到你想要的类
            - 访问信息：比如刚才的MyButton，能拿到它的属性名
        # 创建和操作对象：在不知道具体类型的情况下，也能创建实例并调用方法
    */
    /*
    反射的类、方法常用小文档汇总
        类名：作用
        Type：类型元数据核心，代表类 / 结构体 / 接口 / 枚举，一切反射的起点，相当于这个类的说明说
        Assembly：程序集（exe/dll），可以加载外部 dll
        ConstructorInfo：构造函数信息
        MethodInfo：方法信息，调用方法 `Invoke()`
        PropertyInfo：属性信息，读写属性 `GetValue / SetValue`
        FieldInfo：字段（成员变量）信息
        ParameterInfo：方法参数信息
        CustomAttributeData：特性元数据
    获取Type的2种方式：
        #1 编译期获取，不需要实例
        Type t1 = typeof(Person);

        #2 运行时从对象实例获取
        Person p = new Person();
        Type t2 = p.GetType();
    */
    /*
    高频方法：
        Type常用方法：
            方法	                        用途
            GetMethod("方法名")	            获取 public 方法
            GetMethods()	                获取全部 public 方法数组
            GetProperty("属性名")	        获取属性
            GetProperties()	                获取所有属性
            GetConstructor(types[])	        获取构造函数
            GetCustomAttribute<T>()	        读取特性
            Activator.CreateInstance(type)	创建对象实例（最常用）  //默认调用无参构造函数，如果类中没有无参构造函数，会运行时报错（如果手动写了有参构造函数，类不会再自动创建无参构造函数，需要额外再写一个无参构造函数）
        想要获取私有、静态成员，必须带上 BindingFlags
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
        
        MethodInfo常用方法：
            方法	                            用途
            Invoke(object obj, object[] args)   执行方法；实例方法传实例对象，静态传`null`
            GetParameters()                     拿到参数列表
            MakeGenericMethod(Type[])           调用泛型方法

        PropertyInfo常用方法：
        方法	                            用途
        GetValue(object obj)                读属性值
        SetValue(object obj, object value)  给属性赋值

        FieldInfo常用方法：
        方法	                            用途
        GetValue(object obj)                读字段
        SetValue(object obj, object value)  写字段
    */
    /*
        常用业务场景：
            1. 对象序列化 / 反序列化（Json 框架，遍历对象所有属性）
            2. ORM 框架（EF‑Core）：实体类映射数据库表，读取实体属性
            3. 单元测试框架 xUnit/NUnit：扫描标记特性的测试方法自动运行
            4. 插件化系统：动态加载外部 dll，运行其中的类
            5. 配置驱动：配置文件写类名，程序运行时动态创建对象
            6. AOP 面向切面编程：拦截方法，在方法前后插入逻辑
            7. 读取自定义特性：如`[HttpGet]`、自定义标签
    */

    // 特性
    /*
        特性是一种以声明的方式将信息与代码关联起来的方法。
        它们可应用于各种目标， 可以参考ObsoleteAttribute。
        它可以应用于类、结构、方法、构造函数等。
        它用来声明该元素已过时，然后由C#编译器来查找这个属性，并执行一些响应动作
    */
    /*
    特点：
        #1 特性是一个类，它的作用不是用来直接调用的，而是给“目标”贴标签
        #2 贴标签是为了对目标进行分组，然后对这一组目标进行通用处理
        #3 上面所说的目标包括类、结构、方法、构造函数等等（还有很多，具体见官网）
        #4 特性本身不会对目标进行任何处理，但是如果目标带有xx特性,那就可能要对目标进行额外处理
    */
    public class ReflectionAndAttribute
    {
        public string Serialize(object obj)
        {
            var res = obj.GetType().GetProperties().Select(pi => pi.Name);
            return "" + res;
        }
    }

    public class Cow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Class { get; set; }
    }
    public enum Gender { Male, Female };
}