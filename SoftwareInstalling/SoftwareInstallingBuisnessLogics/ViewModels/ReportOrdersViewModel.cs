using System;
using System.Collections.Generic;
using System.Text;
using SoftwareInstallingBuisnessLogic.Enums;

namespace SoftwareInstallingBuisnessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }

        public string PackageName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }
    }
}
