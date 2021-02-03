using System.Collections.Generic;
using System.ComponentModel;

namespace SoftwareInstallingBuisnessLogic.ViewModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
