using System.Collections.Generic;

namespace GrapheneTrace.Models
{
    public class DashboardViewModel
    {
        public int PeakPressureIndex { get; set; }
        public int ContactAreaPercent { get; set; }
        public int AveragePressure { get; set; }

        // List of patient comments shown on the dashboard
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
