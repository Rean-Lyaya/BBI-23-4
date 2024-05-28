//уровень 9-18 баллов
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;

internal class Program
{
    abstract class Task
    {
        protected string input;
        protected string output;
        protected Task(string text)
        {
            input = text;
        }
        public override string ToString()
        {
            return output;
        }
    }
    class Task1 : Task
    {
        public Task1(string text) : base(text)
        {
            string rus = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            var top = new Dictionary<char, int>();
            foreach (char x in text)
            {
                char sym = char.ToLower(x);
                if (rus.Contains(sym))
                {
                    if (top.ContainsKey(sym)) { top[sym]++; }
                    else { top.Add(sym, 1); }
                }
            }
            int all = 0;
            foreach (int x in top.Values) { all += x; }
            foreach (var x in top)
            {
                output += $"{x.Key}: {(float)x.Value * 100 / all}%\n";
            }
        }
    }
    class Task3 : Task
    {
        public Task3(string text) : base(text)
        {
            int spaceind = text.IndexOf(' ');
            string[] strings = { text.Substring(0, spaceind + 1) };
            int i = 0;
            while (spaceind != -1)
            {
                int n = text.IndexOf(" ", spaceind + 1);
                int nextspaceind = text.IndexOf(" ", spaceind + 1);
                if (nextspaceind == -1)
                {
                    nextspaceind = text.Length - 1;
                }
                if ((strings[i].Length + nextspaceind - spaceind) <= 50)
                {
                    strings[i] += text.Substring(spaceind + 1, nextspaceind - spaceind);
                }
                else
                {
                    strings = strings.Append(text.Substring(spaceind + 1, nextspaceind - spaceind)).ToArray();
                    i++;
                }
                spaceind = n;
            }
            foreach (string str in strings) { output += str + "\n"; }
        }
    }
    class Task5 : Task
    {
        public Task5(string text) : base(text)
        {
            string nums = "0123456789";
            string[] words = text.Split(' ');
            var top = new Dictionary<char, int>();
            foreach (string word in words)
            {
                char sym = char.ToLower(word[0]);
                if (!nums.Contains(sym))
                {
                    if (top.ContainsKey(sym)) { top[sym]++; }
                    else { top.Add(sym, 1); }
                }
            }
            var sorted = top.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int all = 0;
            foreach (int x in sorted.Values) { all += x; }
            foreach (var x in sorted)
            {
                output += $"{x.Key}: {(float)x.Value * 100 / all}%\n";
            }
        }
    }
    class Task7 : Task
    {
        public Task7(string text, string match) : base(text)
        {
            string t = text.ToLower().Replace(match, "@");
            string[] words = t.Split(' ', '.', ',');
            foreach (string word in words)
            {
                if (word.Contains('@')) { output += $"{word.Replace("@", match)}\n"; }
            }
        }
    }
    class Task11 : Task
    {
        public Task11(string text) : base(text)
        {
            string[] last_names = text.Split(',');
            for (int i = 0; i < last_names.Length; i++)
            { if (last_names[i][0] == ' ') { last_names[i] = last_names[i].Substring(1); } }
            Sort(last_names);
            foreach (string name in last_names) { output += $"{name}\n"; }
        }
        private static void Sort(string[] names)
        {
            string temp;
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (Comp(names[i], names[j]))
                    {
                        temp = names[i];
                        names[i] = names[j];
                        names[j] = temp;
                    }
                }
            }
        }
        private static bool Comp(string a, string b)
        {
            if (a == "" & b != "") { return false; }
            if (b == "" & a != "") { return true; }
            if (a == "" & b == "") { return false; }
            if (a[0] > b[0]) { return true; }
            else if (a[0] < b[0]) { return false; }
            return Comp(a.Substring(1), b.Substring(1));
        }
    }
    class Task14 : Task
    {
        public Task14(string text) : base(text)
        {
            int sum = 0;
            int i = 0;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    sum += int.Parse(c.ToString());
                }
            }
            output = sum.ToString();
        }
    }

    static void Main(string[] args)
    {
        string s = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        string last_names = "Иванов, Петров, Смирнов, Соколов, Кузнецов, Попов, Лебедев, Волков, Козлов, Новиков, Иванова, Петрова, Смирнова, Ivanov, Petrov, Smirnov, Sokolov, Kuznetsov, Popov, Lebedev, Volkov, Kozlov, Novikov, Ivanova, Petrova, Smirnova";
        string[] nums = { "Задание 1", "Задание 3", "Задание 5", "Задание 7", "Задание 11", "Задание 14" };
        Task[] tasks = {
            new Task1(s),
            new Task3(s),
            new Task5(s),
            new Task7(s, "ро"),
            new Task11(last_names),
            new Task14(s)
        };
        for (int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine(nums[i]);
            Console.WriteLine(tasks[i]);
        }
    }
}
