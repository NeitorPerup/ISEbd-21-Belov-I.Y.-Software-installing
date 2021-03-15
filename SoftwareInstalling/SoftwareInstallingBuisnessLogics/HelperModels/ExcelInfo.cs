using System;
using System.Collections.Generic;
using System.Text;
using SoftwareInstallingBuisnessLogic.ViewModels;

namespace SoftwareInstallingBuisnessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportComponentPackageViewModel> ComponentPackages { get; set; }
    }
}
