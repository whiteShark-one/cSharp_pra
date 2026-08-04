using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rookieTutorial.AdvancedFeature;

namespace rookieTutorial.AdvancedFeature
{
    public delegate bool NeedSwap(Student a, Student b);
    public class Student
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public double Height { get; set; }
        public Student(int id, int score, double height)
        {
            Id = id;
            Score = score;
            Height = height;
        }
        public void Show()
        {
            Console.WriteLine($"Id: {Id} Score: {Score} Height: {Height}");
        }

        public static void MySort(Student[] arr, NeedSwap compare)
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