using System;
using System.Collections.Generic;
using Core.Entities.Base;
using Core.Entities.Enumerations;

namespace Core.Entities
{
    public class RepeatingConditions : Entity
    {
        public TypeOfRepeatTimeSpan Type { get; set; }
        public int RepeatInterval { get; set; }
        
        public List<DayOfWeek> RepeatingDaysOfWeek { get; set; } = new List<DayOfWeek>();

        /*public string SerializedDaysOfWeek
        {
            get
            {
                return string.Join(",", RepeatingDaysOfWeek.ConvertAll(input => input.ToString()));
            }
            set
            {
                RepeatingDaysOfWeek = value.Split(',')
                    .Where(x => x != "")
                    .Select(x => (DayOfWeek) Enum.Parse(typeof(DayOfWeek), x))
                    .ToList();
            }
        }*/
    }
}