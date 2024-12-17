using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Exceptions;

namespace FitnessBeheerDomain.Model;
public class TimeSlot
{
    public TimeSlot(int id, TimeOnly startTime)
    {
        if (startTime.Hour < 8 || startTime.Hour >= 22)
            throw new TimeSlotException("StartTime must be between 08:00 and 22:00.");

        Id = id;
        StartTime = startTime;
    }

    public int Id { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime => StartTime.AddHours(1);
    public string PartOfDay
    {
        get
        {
            if (StartTime.Hour < 12)
                return "Morning";

            if (StartTime.Hour < 18)
                return "Afternoon";

                return "Evening";
        }
    }

    public bool OverlapsWith(TimeSlot other)
    {
        return StartTime < other.EndTime && EndTime > other.StartTime;
    }

}

