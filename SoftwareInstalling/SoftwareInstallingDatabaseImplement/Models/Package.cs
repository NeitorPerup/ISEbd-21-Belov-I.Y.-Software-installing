using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareInstallingDatabaseImplement.Models
{
    public class Package
    {
        public int Id { get; set; }

        [ForeignKey("PackageId")]
        public virtual List<PackageComponent> PackageComponent { get; set; }

        [ForeignKey("PackageId")]
        public virtual List<Order> Order { get; set; }

        [Required]
        public string PackageName { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
