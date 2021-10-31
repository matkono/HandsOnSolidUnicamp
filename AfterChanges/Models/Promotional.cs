using System;

namespace AfterChanges.Models
{
    public class Promotional
    {
        public int MonthsExemption { get; set; }

        public DateTime DateStart { get; set; }

        public Promotional(int monthsExemption, DateTime dateStart) 
        {
            MonthsExemption = monthsExemption;
            DateStart = dateStart;
        }
    }
}
