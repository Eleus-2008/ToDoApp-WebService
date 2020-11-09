using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Model.Enums;
using ToDoApp.Model.Interfaces;

namespace ToDoApp.Model
{
    public class RepeatingConditions : IEntity
    {
        public int Id { get; set; }
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