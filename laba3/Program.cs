namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    namespace ConsoleAppDelete
    {
        class Program
        {
            public static void Main(string[] args)
            {
                List<List<string>> words;
                string[] longestWords;

                if (args.Length >= 1)
                {
                    words = InputTextFromFile(args[0]);
                    longestWords = ShowLongestWords(words);
                    if (args.Length >= 2)
                    {
                        OutputWordsToFile(longestWords, args[1]);
                    }
                }
                else
                {
                    words = ManualInput();
                    ShowLongestWords(words);
                }

                Console.ReadKey();
            }
            //public static void Main()
            //{
            //    List<List<string>> words;
            //    string[] longestWords;


            //    Console.WriteLine("Введите '0', если хотите работать с файлом");
            //    int choose = int.Parse(Console.ReadLine());
            //    if (choose == 0)
            //    {
            //        Console.WriteLine("Введите путь файла");
            //        string pathfile = Console.ReadLine();

            //        words = InputTextFromFile(pathfile);
            //        longestWords = ShowLongestWords(words);
            //        Console.WriteLine("Введите '0', вывести результат в в файл");

            //        choose = int.Parse(Console.ReadLine());
            //        if (choose == 0)
            //        {
            //            Console.WriteLine("Введите имя файла");
            //            pathfile = Console.ReadLine();
            //            OutputWordsToFile(longestWords, pathfile);
            //        }
            //    }
            //    else
            //    {
            //        words = ManualInput();
            //        ShowLongestWords(words);
            //    }

            //    Console.ReadKey();
            //}


            private static void OutputWordsToFile(string[] longestWords, string fileName)
            {
                var wordStringBuilder = new StringBuilder();

                foreach (var word in longestWords)
                {
                    wordStringBuilder.Append(word + ", ");
                }

                File.WriteAllText(fileName, wordStringBuilder.ToString().Substring(0, wordStringBuilder.Length - 2));

            }

            private static List<List<string>> InputTextFromFile(string fileName)
            {
                List<List<string>> words = new List<List<string>>();
                words = File.ReadAllLines(fileName)
                    .Select(line => new List<string>(line.Split(' ')))
                    .ToList();




                Console.WriteLine($"Текст из файла {fileName} прочитан.");
                return words;
            }

            public static List<List<string>> ManualInput()
            {
                int linesCount;
                List<List<string>> words = new List<List<string>>();

                Console.Write("Введите количество строк: ");
                linesCount = int.Parse(Console.ReadLine());


                for (int i = 0; i < linesCount; i++)
                {
                    Console.Write($"\nВведите строку {i + 1}:");
                    words.Add(new List<string>(Console.ReadLine().Split(' ')));
                }

                return words;
            }

            public static string[] ShowLongestWords(List<List<string>> words)
            {
                int linesCount = words.Count;
                string[] longestWords;

                longestWords = new string[linesCount];
                for (int i = 0; i < linesCount; i++)
                {
                    int maxLength = 0;
                    foreach (var word in words[i])
                    {
                        if (word.Length > maxLength)
                        {
                            maxLength = word.Length;
                            longestWords[i] = word;
                        }
                    }
                }


                Console.WriteLine($"Самые длинные слова:");
                int count = 1;
                foreach (var word in longestWords)
                {
                    Console.WriteLine($"{count++}) {word}");
                }

                return longestWords;

            }
        }
    }
}