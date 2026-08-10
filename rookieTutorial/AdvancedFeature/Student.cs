using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rookieTutorial.AdvancedFeature;

namespace rookieTutorial.AdvancedFeature
{
    // public delegate bool NeedSwap(Student a, Student b);
    // 使用Func() 定义标准委托

    public delegate bool NeedSwap(Student a, Student b);
    // [Author("李珅",Version = "1.0.0")] // Author和AuthorAttribute两种写法都可
    // [AuthorAttribute("李珅",Version ="1.0.0")]
    // [Remark(Info = "学生实体类，用于存储账号信息")] // 采用该写法，会先调用无参构造函数，需要先手写无参构造函数
    [Remark("学生实体类，用于存储账号信息")]
    public class Student
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public double Height { get; set; }
        public Student(){}
        public Student(int id, int score, double height)
        {
            Id = id;
            Score = score;
            Height = height;
        }
        [Author("李珅")]
        public void Study()
        {
            
        }
        public void sayHi(string msg)
        {
            Console.WriteLine($"Hi,{Id},{msg}");
        }
        public void Show()
        {
            Console.WriteLine($"Id: {Id} Score: {Score} Height: {Height}");
        }

        // public static void MySort(Student[] arr, NeedSwap compare)
        public static void MySort(Student[] arr, Func<Student,Student,bool> compare)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (compare(arr[j], arr[j + 1]))
                    {
                        Student temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public static bool IdAsc(Student a, Student b)
        {
            return a.Id > b.Id;
        }
        public static bool IdDesc(Student a, Student b)
        {
            return a.Id < b.Id;
        }
        public static bool ScoreAsc(Student a, Student b)
        {
            return a.Score > b.Score;
        }
        public static bool ScoreDesc(Student a, Student b)
        {
            return a.Score < b.Score;
        }
        public static bool HeightAsc(Student a, Student b)
        {
            return a.Height > b.Height;
        }
        public static bool HeightDesc(Student a, Student b)
        {
            return a.Height < b.Height;
        }



    }
}