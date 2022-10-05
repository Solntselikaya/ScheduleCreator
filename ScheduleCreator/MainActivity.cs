using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;
using ScheduleCreator._study;

namespace ScheduleCreator
{
    internal class MainActivity
    {
        static void Main()
        {
            InputData.inputTeachers.Add(new Teacher("Пупкин"));
            InputData.inputTeachers.Add(new Teacher("Залупкин"));
            InputData.inputTeachers.Add(new Teacher("Пупов"));
            InputData.inputTeachers.Add(new Teacher("Запупов"));

            foreach (var i in Enumerable.Range(100, 150).ToArray())
            {
                InputData.inputClassrooms.Add(new Classroom(i.ToString()));
            }

            InputData.inputStudyPlans.Add(new StudyPlan("972103",
                new List<Tuple<Lesson, LType>> {
                    new Tuple<Lesson, LType>(
                        new Lesson("Пупкин", "Хйня какая-то"), LType.Seminar) 
                }));

            InputData.inputStudyPlans.Add(new StudyPlan("962105",
                new List<Tuple<Lesson, LType>> {
                    new Tuple<Lesson, LType>(
                        new Lesson("Пупкин", "Хйня какая-то"), LType.Seminar)
                }));

            Schedule sched = new Schedule();
        }
    }
}
