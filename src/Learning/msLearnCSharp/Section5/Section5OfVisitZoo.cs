using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msLearnCSharp.Section5
{
    public class Section5OfVisitZoo
    {
        // 指导项目 - 计划宠物动物园参观
        string[] pettingZoo =
            {
                "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
                "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
                "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
            };

        public void PlanSchoolVisit(string schoolName, int groups = 6)
        {
            RandomizeAnimals();
            string[,] group = AssignGroup(groups);
            Console.WriteLine(schoolName);
            PrintGroup(group);
        }
        public void RandomizeAnimals()
        {
            Random random = new Random();
            for (int i = 0; i < pettingZoo.Length; i++)
            {
                int r = random.Next(i, pettingZoo.Length);

                string temp = pettingZoo[i];
                pettingZoo[i] = pettingZoo[r];
                pettingZoo[r] = temp;
            }
        }
        public string[,] AssignGroup(int groups = 6)
        {
            string[,] result = new string[groups, pettingZoo.Length / groups];
            int start = 0;
            for (int i = 0; i < groups; i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = pettingZoo[start++];
                }
            }
            return result;
        }

        public void PrintGroup(string[,] groups)
        {
            for (int i = 0; i < groups.GetLength(0); i++)
            {
                Console.Write($"Group {i + 1}: ");
                for (int j = 0; j < groups.GetLength(1); j++)
                {
                    Console.Write($"{groups[i, j]}  ");
                }
                Console.WriteLine();
            }
        }

    }
}