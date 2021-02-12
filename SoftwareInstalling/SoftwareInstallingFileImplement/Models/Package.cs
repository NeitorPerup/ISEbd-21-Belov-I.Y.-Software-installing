using System.Collections.Generic;

namespace SoftwareInstallingFileImplements.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> ProductComponents { get; set; }
    }
}
