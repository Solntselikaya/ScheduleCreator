using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;
using ScheduleCreator._study;

namespace ScheduleCreator._timetable
{
    internal class Timetable : ITimetable
    {
        private Study[,] timetable = new Study[6,7];

        public Timetable(StudyPlan plan)
        {
            foreach (var lesson in plan.listOfLessons)
            {
                PlaceInTable(lesson);
            }
        }
        public Study[,] GetTimetable()
        {
            return timetable;
        }

        private void PlaceInTable(Tuple<Lesson, LType> lesson)
        {
            var (l, type) = lesson;
            var teacher = l.GetTeacher();

            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    //отсюда и ниже лучше вынести в другой метод
                    //итерация - одно, операция - другое
                    if (!teacher.IsFree(i, j))
                        continue;
                    
                    foreach(var classroom in InputData.inputClassrooms)
                    {
                        if (!classroom.IsFree(i, j) || timetable[i, j].GetLesson() != null)
                            continue;

                        timetable[i, j] = new Study(l, classroom, type);

                        teacher.DoBusy(i, j);
                        classroom.DoBusy(i, j);
                        //Console.WriteLine($"{i}, {j}");
                        return;
                    }
                }
            }
        }
    }
}
