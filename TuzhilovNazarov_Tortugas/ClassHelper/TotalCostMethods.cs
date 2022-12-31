using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TuzhilovNazarov_Tortugas.ClassHelper
{
    public class TotalCostMethods
    {
        public static decimal FifthSaturdayDiscount(DateTime date, decimal cost)
        {
            int Month = date.Month;
            int Year = date.Year;
            int allDayMonth = DateTime.DaysInMonth(Year, Month);
            DateTime first = new DateTime(Year, Month, 1);
            DateTime last = new DateTime(Year, Month, allDayMonth);
            DateTime fith;
            DayOfWeek dayOfWeek = DayOfWeek.Saturday;
            int number = 0;

            while (first <= last)
            {
                if (first.DayOfWeek == dayOfWeek)
                    break;

                first = first.AddDays(1);
            }

            while (first <= last)
            {
                number++;

                if (number == 5)
                {
                    fith = first;
                }

                first = first.AddDays(7);
            }
            if (number == 5 || date == first.AddDays(-7))
            {
                return (cost - Convert.ToDecimal(Convert.ToDouble(cost) * 0.1));
                MessageBox.Show("Ura!");
            }
            else
            {
                return cost;
            }

        }
    }
}
