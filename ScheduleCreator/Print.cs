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
    internal static class Print
    {
        public static void PrintTimetableOfGroup(string number, Timetable timetable)
        {
            Console.WriteLine($"Расписание группы №{number}");
            Console.WriteLine(" ");
            Console.WriteLine("Понедельник");
            printDayTimetable(0, number, timetable);
            Console.WriteLine("Вторник");
            printDayTimetable(1, number, timetable);
            Console.WriteLine("Среда");
            printDayTimetable(2, number, timetable);
            Console.WriteLine("Четверг");
            printDayTimetable(3, number, timetable);
            Console.WriteLine("Пятница");
            printDayTimetable(4, number, timetable);
            Console.WriteLine("Суббота");
            printDayTimetable(5, number, timetable);
        }

        private static void printDayTimetable(int day, string number, Timetable timetable)
        {
            Study[,] nowTimetable = timetable.GetTimetable();
            for (int i = 0; i < 7; i++)
            {
                switch (nowTimetable[day, i].GetType().ToString())
                {
                    case "Lecture":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Seminar":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "Practice":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "Lab":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Test":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                Console.WriteLine(" ");
                Console.WriteLine($"Пара №{i} - {nowTimetable[day, i].GetLesson().GetName()}");
                Console.WriteLine($"Аудитория №{nowTimetable[day, i].GetClassroom().GetName()}");
                Console.WriteLine($"Преподаватель - {nowTimetable[day, i].GetLesson().GetTeacher().GetName()}");
                Console.WriteLine(" ");
                Console.ResetColor();
            }
        }
    }
}
