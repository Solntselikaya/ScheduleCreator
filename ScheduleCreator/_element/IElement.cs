using System;
using System.Threading.Tasks;

namespace ScheduleCreator._element
{
    public interface IElement
    {
        bool IsFree(int day, int lesson);
    }
}
