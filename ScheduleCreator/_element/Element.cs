using System;
using System.Threading.Tasks;

namespace ScheduleCreator._element
{
    abstract class Element: IElement
    {
        protected string name = "Undefined";
        protected bool[,] workload = new bool[6, 7]; //массив 6 на 7 (6 дней и каждый день максимум 7 пар)

        public Element(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
        
        public bool IsFree(int day, int lesson)
        {
            if (day >= 0 && day < 6 && lesson >= 0 && lesson < 7)
                return !workload[day, lesson];
            else 
                return false;
        }

        public void DoBusy(int day, int lesson)
        {
            if (day >= 0 && day < 6 && lesson >= 0 && lesson < 7)
                workload[day,lesson] = true;
            else Console.WriteLine("Ошибка ввода даты или номера пары");
        }
    }
}
