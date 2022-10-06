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
    internal class Schedule
    {
        private Dictionary<string, ITimetable> schedule = new Dictionary<string, ITimetable>();

        public Schedule()
        {
            foreach(var plan in InputData.inputStudyPlans)
            {
                schedule.Add(plan.numOfGroup, new Timetable(plan));
            }
        }

        public Dictionary<string, ITimetable> GetSchedule()
        {
            return schedule;
        }
    }
}
