using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Common
{
    public class MonthlyStatsViewModel
    {
        //1/January/2026
        public int Month { get; set; } //Jan = 1, Feb = 2, ...
        public int Year { get; set; }

        public double AbsenteesimPercentage { get; set; }
    }
}
