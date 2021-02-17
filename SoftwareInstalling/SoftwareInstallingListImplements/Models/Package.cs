﻿using System.Collections.Generic;

namespace SoftwareInstallingListImplements.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string PackageName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> PackageComponents { get; set; }
    }
}
