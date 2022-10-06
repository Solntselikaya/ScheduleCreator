using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;
using ScheduleCreator._study;
using ScheduleCreator._timetable;

namespace ScheduleCreator
{
    internal class MainActivity
    {
        private static Schedule schedule;

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в составитель расписания!");

            AssignTeachers();
            AssignClassrooms();
            AssignStudyPlans();

            schedule = new Schedule();
        }

        public static void AssignTeachers()
        {
            Console.WriteLine("Введите преподавателей, пары которых будут стоять в расписании (имена через знак запятой):");
            var res = Console.ReadLine();

            while (res == "")
            {
                Console.WriteLine("Вы ничего не ввели! Повторите ввод:");
                res = Console.ReadLine();
            }

            string[] names = res.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
                InputData.inputTeachers.Add(new Teacher(name));
        }

        public static void AssignClassrooms()
        {
            Console.WriteLine("Введите номера аудиторий, в которых будут проходить пары (через знак запятой):");
            var res = Console.ReadLine();

            while (res == "")
            {
                Console.WriteLine("Вы ничего не ввели! Повторите ввод:");
                res = Console.ReadLine();
            }

            string[] nums = res.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var num in nums)
                InputData.inputClassrooms.Add(new Classroom(num));
        }

        public static void AssignStudyPlans()
        {
            Console.WriteLine("Введите учебные планы для групп по формату:");
            Console.WriteLine("Номер группы -> на след. строке: [Имя_1преподвателя!Название_1пары!Тип_1пары],[] и т.д.:");
            Console.WriteLine("(Доступные типы пар: Lecture, Seminar, Practice, Lab, Test)");
            Console.WriteLine("(Если ввод окончен, нажмите ctrl+z)");

            string group;
            while ((group = Console.ReadLine()) != null)
            {
                while (group == "")
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод номера группы:");
                    group = Console.ReadLine();
                }

                var res = Console.ReadLine();
                while (res == "" || res == null)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод списка пар:");
                    res = Console.ReadLine();
                }

                List<Tuple<Lesson, LType>> currPairs = new List<Tuple<Lesson, LType>>();
                string[] pairs = res.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in pairs)
                {
                    string[] names = pair.Split('!', StringSplitOptions.RemoveEmptyEntries);
                    var check = InputData.inputTeachers.Find(x => x.GetName() == names[0]);

                    if (names[0] != null && names[1] != null && check != null)
                    {
                        switch (names[2])
                        {
                            case "Lecture":
                                currPairs.Add(new Tuple<Lesson, LType>(
                                    new Lesson(names[0], names[1]), LType.Lecture));
                                break;
                            case "Seminar":
                                currPairs.Add(new Tuple<Lesson, LType>(
                                    new Lesson(names[0], names[1]), LType.Seminar));
                                break;
                            case "Practice":
                                currPairs.Add(new Tuple<Lesson, LType>(
                                    new Lesson(names[0], names[1]), LType.Practice));
                                break;
                            case "Lab":
                                currPairs.Add(new Tuple<Lesson, LType>(
                                    new Lesson(names[0], names[1]), LType.Lab));
                                break;
                            case "Test":
                                currPairs.Add(new Tuple<Lesson, LType>(
                                    new Lesson(names[0], names[1]), LType.Test));
                                break;
                            default:
                                Console.WriteLine("В вводе типа пары была ошибка! Пара не внесена");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("В вводе имени пары/имени преподавателя была ошибка! Пара не внесена");
                }

                if (currPairs.Count > 0)
                    InputData.inputStudyPlans.Add(new StudyPlan(group, currPairs));
                else
                    Console.WriteLine("План не добавлен, т.к. не введены пары!");
            }
        }  
    }
}
