using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;

namespace ScheduleCreator._study
{
    internal struct Study
    {
        private Lesson lesson;
        private Classroom classroom;
        private LType lessonType;

        public Study(Lesson lesson, Classroom classroom, LType lessonType)
        {
            this.lesson = lesson;
            this.classroom = classroom;
            this.lessonType = lessonType;
        }
    }
}
