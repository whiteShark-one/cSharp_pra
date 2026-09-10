using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rookieTutorial.Basics
{
    struct Vectors3<T>
    {
        public T x,y,z;
        public Vectors3(T x,T y,T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Show()
        {
            Console.WriteLine($"{x}, {y}, {z}");
        }

    }
    class Pair<T1, T2>
    {
        public T1 first;
        public T2 second;
        // public Pair(){}
        public Pair(T1 first, T2 second)
        {
            this.first = first;
            this.second = second;
        }
        public void Show()
        {
            Console.WriteLine($"First: {first}, Second: {second}");
        }
    }
    public class learnGeneric
    {
        public void displayStruct()
        {
            Vectors3<double> v =new Vectors3<double>(1.0,2.0,3.0);
            v.Show();

            Vectors3<float> v1 =new Vectors3<float>(1.0f,2.0f,3.0f);
            v1.Show();

            Vectors3<int> v2 =new Vectors3<int>(1,2,3);
            v2.Show();

            Pair<int,string> pair = new Pair<int, string>(2,"pair");
            pair.Show();

        }
        /*
            没有 ref：方法内部交换的只是副本，外面原始变量完全不变。
            加上 ref：传递变量本身的内存地址，方法内部修改，外面实参跟着一起变。
        */
        public void Swap<T>(ref T a, ref T b)
        // public void Swap<T>(T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}