using System.Collections.Generic;

namespace SoftwareInstallingBuisnessLogic.BindingModels
{
    public class PackageBindingModel
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
