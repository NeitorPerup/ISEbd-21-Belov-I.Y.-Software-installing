using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using SoftwareInstallingBuisnessLogic.Attributes;

namespace SoftwareInstallingBuisnessLogic.ViewModels
{
    [DataContract]
    public class PackageViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PackageName { get; set; }

        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}
