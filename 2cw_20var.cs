//Вариант 20
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello students ;)";
            string text1 = "Hello John and Mary! How are you doing today?";
            string[] tasks = { Task1(text), Task2(text1) };

            Console.WriteLine(tasks[0]); // Вывод результата первой задачи

            Task3();

            JsonIO jsonIO = new JsonIO();
            jsonIO.HandleJsonFiles(text, tasks[0], tasks[1]);
        }

        // Задание 1
        public static string Task1(string input)
        {
            char[] delimiters = new char[] { ' ', ';', '.', ',', '!', '?' };
            string[] words = SplitString(input, delimiters);
            int middleIndex = words.Length / 2;

            return words.Length % 2 == 0 ? words[middleIndex - 1] : words[middleIndex];
        }

        // Задание 2:
        public static string Task2(string input)
        {
            char[] delimiters = new char[] { ' ', ';', '.', ',', '!', '?' };
            string[] words = SplitString(input, delimiters);
            List<string> properNouns = new List<string>();

            foreach (string word in words)
            {
                if (char.IsUpper(word[0]) && word.Length > 1)
                {
                    properNouns.Add(word);
                }
            }

            return string.Join(Environment.NewLine, properNouns);
        }

        private static string[] SplitString(string input, char[] delimiters)
        {
            List<string> words = new List<string>();
            int start = 0, end;

            for (int i = 0; i <= input.Length; i++)
            {
                if (i == input.Length || Array.IndexOf(delimiters, input[i]) != -1)
                {
                    end = i;
                    if (end > start)
                    {
                        words.Add(input.Substring(start, end - start));
                    }
                    start = i + 1;
                }
            }

            return words.ToArray();
        }

        // Задание 3: 
        public static void Task3()
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string folderPath = Path.Combine(userPath, "UserDirectory", "Fourth Task");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath1 = Path.Combine(folderPath, "string_1.json");
            string filePath2 = Path.Combine(folderPath, "string_2.json");

            // Закомментировано создание файлов
            // if (!File.Exists(filePath1))
            // {
            //     File.Create(filePath1).Close();
            // }

            // if (!File.Exists(filePath2))
            // {
            //     File.Create(filePath2).Close();
            // }
        }
    }

    // Задание 4: Работа с JSON
    public class JsonIO
    {
        public void HandleJsonFiles(string input, string task1Output, string task2Output)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string folderPath = Path.Combine(userPath, "UserDirectory", "Fourth Task");
            string filePath = Path.Combine(folderPath, "data.json");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var data = new
            {
                Input = input,
                Task1Output = task1Output,
                Task2Output = task2Output.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            };
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var existingData = JsonConvert.DeserializeObject<object>(jsonData);
                Console.WriteLine(JsonConvert.SerializeObject(existingData, Formatting.Indented));
            }
            else
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
        }
    }
}
