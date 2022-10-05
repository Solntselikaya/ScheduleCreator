using System;
using System.Threading.Tasks;

namespace ScheduleCreator._element
{
    class Teacher : Element
    {
        public List<string> subjects = new List<string>();

        public Teacher(string name): base(name) { }
    }
}
