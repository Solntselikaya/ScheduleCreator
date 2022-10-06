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

        public Study[,] GetTimetable()
        {
            return timetable;
        }

        public Timetable(StudyPlan plan)
        {
            foreach (var lesson in plan.listOfLessons)
            {
                PlaceInTable(lesson);
            }
        }

        private void PlaceInTable(Tuple<Lesson, LType> lesson)
        {
            var (l, type) = lesson;
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    var teacher = l.GetTeacher();

                    if (!teacher.IsFree(i, j))
                        continue;
                    
                    foreach(var classroom in InputData.inputClassrooms)
                    {
                        if (!classroom.IsFree(i, j))
                            continue;

                        timetable[i, j] = new Study(l, classroom, type);

                        teacher.DoBusy(i, j);
                        classroom.DoBusy(i, j);

                        return;
                    }
                }
            }
        }
    }
}
