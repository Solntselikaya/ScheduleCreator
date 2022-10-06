using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;

namespace ScheduleCreator._study
{
    internal struct StudyPlan
    {
        public string numOfGroup = "Undefined"; //лучше айди
        public List<Tuple<Lesson, LType>> listOfLessons = new List<Tuple<Lesson, LType>>(42);
        //лучше константы вынести в отдельный класс констант!

        public StudyPlan(string num, List<Tuple<Lesson, LType>> list)
        {
            numOfGroup = num;
            listOfLessons = list;
        }
    }
}
