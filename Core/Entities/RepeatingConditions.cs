using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Base;
using Core.Entities.Enumerations;

namespace Core.Entities
{
    public class RepeatingConditions : Entity
    {
        public TypeOfRepeatTimeSpan Type { get; set; }
        public int RepeatInterval { get; set; }
        
        public List<DayOfWeek> RepeatingDaysOfWeek { get; set; } = new List<DayOfWeek>();
    }
}