using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareInstallingBuisnessLogic.BindingModels
{
    public class WarehouseRestokingBindingModel
    {
        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
