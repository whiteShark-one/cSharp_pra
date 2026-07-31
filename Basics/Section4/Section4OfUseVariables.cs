using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharp_pra.Basics.Section4
{
    public class Section4OfUseVariables
    {
        // 引导式项目 - 在 C# 使用变量数据
        // 宠物公司的练习项目
        public void useVariablesOne()
        {
            // #1 the ourAnimals array will store the following: 
            string animalSpecies = "";
            string animalID = "";
            string animalAge = "";
            string animalPhysicalDescription = "";
            string animalPersonalityDescription = "";
            string animalNickname = "";
            // 新增捐赠金额
            string suggestedDonation = "";

            // #2 variables that support data entry
            int maxPets = 8;
            /*
                使用 Console.ReadLine() 该方法读取用户输入的值时，最好启用可为 null 的类型字符串 string?，以避免生成项目时的代码编译器生成警告。
            */
            string? readResult;
            string menuSelection = "";
            decimal decimalDonation = 0.00m;

            // #3 array used to store runtime data, there is no persisted data
            string[,] ourAnimals = new string[maxPets, 7];

            // #4 create sample data ourAnimals array entries
            for (int i = 0; i < maxPets; i++)
            {
                switch (i)
                {
                    case 0:
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "lola";
                        suggestedDonation = "85.00";
                        break;

                    case 1:
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "gus";
                        suggestedDonation = "49.99";
                        break;

                    case 2:
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "snow";
                        suggestedDonation = "40.00";
                        break;

                    case 3:
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "lion";
                        suggestedDonation = "";

                        break;

                    default:
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;
                }

                ourAnimals[i, 0] = "ID #: " + animalID;
                ourAnimals[i, 1] = "Species: " + animalSpecies;
                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                if (!decimal.TryParse(suggestedDonation, out decimalDonation))
                {
                    decimalDonation = 45.00m;
                }
                // ourAnimals[i, 6] = "suggestedDonation" + suggestedDonation;
                // ourAnimals[i,6] = String.Format($"SuggestedDonation: {decimalDonation:C}"); // 错误嵌套用法，直接用$""即可，只有使用{0}{1}时才用String.Format()
                ourAnimals[i, 6] = $"SuggestedDonation: {decimalDonation:C2}";

            }

            // #5 display the top-level menu options
            do
            {
                // NOTE: the Console.Clear method is throwing an exception in debug sessions
                Console.Clear();

                Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
                Console.WriteLine(" 1. List all of our current pet information");
                Console.WriteLine(" 2. Display all dogs with a specified characteristic");
                Console.WriteLine();
                Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                // use switch-case to process the selected menu option
                switch (menuSelection)
                {
                    case "1":
                        // list all pet info
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 0] != "ID #: ")
                            {
                                Console.WriteLine();
                                for (int j = 0; j < 7; j++)
                                {
                                    Console.WriteLine(ourAnimals[i, j]);
                                }
                            }
                        }
                        Console.WriteLine("\n\rPress the Enter key to continue");
                        readResult = Console.ReadLine();
                        break;

                    case "2":
                        // Display all dogs with a specified characteristic");
                        // Console.WriteLine("\nUNDER CONSTRUCTION - please check back next month to see progress.");
                        // Console.WriteLine("Press the Enter key to continue.");
                        // readResult = Console.ReadLine();
                        // break;
                        // Display all dogs with a specified characteristic
                        string dogCharacteristic = "";
                        while (dogCharacteristic == "")
                        {
                            // have the user enter physical characteristics to search for
                            Console.WriteLine($"\nEnter one desired dog characteristics to search for");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                dogCharacteristic = readResult.ToLower().Trim();
                            }
                        }

                        string dogDescription = "";
                        bool noMatchesDog = true;

                        // #6 loop through the ourAnimals array to search for matching animals
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 1].Contains("dog"))
                            {
                                dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                                if (dogDescription.Contains(dogCharacteristic))
                                {
                                    Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                                    Console.WriteLine(dogDescription);

                                    noMatchesDog = false;
                                }
                            }
                        }
                        if (noMatchesDog)
                        {
                            Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
                        }
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    default:
                        break;
                }
            } while (menuSelection != "exit");


        }
    }
}