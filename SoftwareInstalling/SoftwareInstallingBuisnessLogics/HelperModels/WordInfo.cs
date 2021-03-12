﻿using System;
using System.Collections.Generic;
using System.Text;
using SoftwareInstallingBuisnessLogic.ViewModels;

namespace SoftwareInstallingBuisnessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ComponentViewModel> Components { get; set; }

        public List<PackageViewModel> Packages { get; set; }
    }
}
