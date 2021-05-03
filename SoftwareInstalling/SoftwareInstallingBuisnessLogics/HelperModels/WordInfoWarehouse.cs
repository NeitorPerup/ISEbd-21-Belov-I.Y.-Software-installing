using System;
using System.Collections.Generic;
using SoftwareInstallingBuisnessLogic.ViewModels;

namespace SoftwareInstallingBuisnessLogic.HelperModels
{
    public class WordInfoWarehouse
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
