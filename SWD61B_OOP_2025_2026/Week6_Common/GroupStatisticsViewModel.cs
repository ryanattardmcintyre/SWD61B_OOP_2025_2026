using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Common
{
    public class GroupStatisticsViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int TotalCount { get; set; }

        public double AbsenteeismPercentage { get; set; }
    }

    public class UnitStatisticsViewModel //carry the data
    {
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public double AbsenteeismPercentage { get; set; }
    }

}
