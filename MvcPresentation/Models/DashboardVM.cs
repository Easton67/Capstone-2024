using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPresentation.Models
{
    public class DashboardVM
    {
        public ChartVM ChartData { get; set; }
        public string UserCount { get; set; }
        public string InventoryCount { get; set; }
        public string VenderCount { get; set; }
        public Employee CEO { get; set; }
        public Employee Security { get; set; }
        public string DonationAmount { get; set; }
        public int DonationCount { get; set; }
    }

    public class ChartVM
    {
        public List<string> Labels { get; set; }
        public List<ChartDS> Datasets { get; set; }
    }

    public class ChartDS
    {
        public string Label { get; set; }
        public string BGColor { get; set; }
        public string BRColor { get; set; }
        public List<int> Data { get; set; }
    }
}