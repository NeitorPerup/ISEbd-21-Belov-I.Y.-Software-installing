using System;
using System.Collections.Generic;
using SoftwareInstallingBuisnessLogic.Interfaces;

namespace SoftwareInstallingBuisnessLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }

        public int PopPort { get; set; }

        public IMessageInfoStorage Storage { get; set; }
    }
}
