using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleCreator._element;

namespace ScheduleCreator._study
{
    internal class Lesson
    {
        private Teacher teacher;
        private string name = "Undefined";

        public Lesson(string teacher, string name)
        {
            SetName(name);
            SetTeacher(teacher);
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public Teacher GetTeacher()
        {
            return teacher;
        }

        public void SetTeacher(string teacherName)
        {
            try
            {
                var res = InputData.inputTeachers.Find(x => x.GetName() == teacherName);

                /*
                if (res == null)
                {
                    throw new Exception("Нет такого преподавателя в базе!");
                    //Console.WriteLine("Нет такого преподавателя в базе!");
                    //return;
                }
                */

                teacher = res;
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
