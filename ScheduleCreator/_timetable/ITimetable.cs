using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;
using ScheduleCreator._study;

namespace ScheduleCreator._timetable
{
    internal interface ITimetable
    {
        public Study[,] GetTimetable();
    }
}
