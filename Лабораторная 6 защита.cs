using System;
using System.Collections.Generic;

namespace Level1
{
    // Абстрактный класс Subject, представляющий учебный предмет
    abstract class Subject
    {
        // Защищенное поле _students, содержащее список студентов
        protected List<Student> _students = new List<Student>();

        // Метод для добавления студента в список
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        // Метод для сортировки студентов по оценкам с помощью сортировки Шелла гэп кол во на два 
        public void ShellSortStudents()// по возрастанию / сравнение элементов на определенном расстояние 
        {
            int n = _students.Count;// кол во студентов 
            int gap = n / 2;//Начальный промежуток равен половине количества студентов

            while (gap >= 1)// покапромежуток не будет больше или 1
            {
                for (int i = gap; i < n; i++)// Проход по всем элементам, начиная с индекса gap
                {
                    {
                        Student temp = _students[i];//сохр текущ студента 
                        int j;//сюда в во времен перемен 
                        for (j = i; j >= gap && _students[j - gap].Mark > temp.Mark; j -= gap)// марк возвращает знач оценки студентов 
                        {
                            _students[j] = _students[j - gap]; //перемещаем студента
                        }
                        _students[j] = temp;// вставляем временного студента на правильн место
                    }
                    gap /= 2;//уменьш промежуток вдвое
                }
            }
        }

        // Абстрактный метод для вывода списка студентов, который должен быть реализован в производных классах
        public abstract void PrintStudents();
    }

    // Класс ComputerScience, производный от Subject, представляющий предмет информатика
    class ComputerScience : Subject
    {
        // Реализация абстрактного метода PrintStudents для вывода студентов, изучающих информатику
        public override void PrintStudents()
        {
            Console.WriteLine("Студенты по информатике:");
            ShellSortStudents();
            foreach (var student in _students)
            {
                student.Print();
            }
        }
    }

    // Класс Mathematics, производный от Subject, представляющий предмет математика
    class Mathematics : Subject
    {
        // Реализация абстрактного метода PrintStudents для вывода студентов, изучающих математику
        public override void PrintStudents()
        {
            Console.WriteLine("Студенты по математике:");
            ShellSortStudents();
            foreach (var student in _students)
            {
                student.Print();
            }
        }
    }

    // Класс Student, представляющий студента
    class Student
    {
        private string _name; // Имя студента
        private int _mark;    // Оценка студента
        private int _missed;  // Количество пропущенных занятий

        // Конструктор для инициализации имени, оценки и количества пропущенных занятий
        public Student(string name, int mark, int missed)
        {
            _name = name;
            _mark = mark;
            _missed = missed;
        }

        // Свойство для получения оценки студента
        public int Mark => _mark;

        // Метод для вывода информации о студенте
        public void Print()
        {
            Console.WriteLine($"{_name} - оценка: {_mark}, пропущенных занятий: {_missed}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта ComputerScience и добавление студентов
            var computerScience = new ComputerScience();
            computerScience.AddStudent(new Student("Иванов", 5, 3));
            computerScience.AddStudent(new Student("Петров", 2, 17));

            // Создание объекта Mathematics и добавление студентов
            var mathematics = new Mathematics();
            mathematics.AddStudent(new Student("Сидоров", 3, 6));
            mathematics.AddStudent(new Student("Александров", 2, 9));

            // Вывод списка студентов по информатике
            computerScience.PrintStudents();

            // Вывод списка студентов по математике
            mathematics.PrintStudents();
        }
    }
}

