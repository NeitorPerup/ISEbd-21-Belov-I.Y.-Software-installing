﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SoftwareInstallingBuisnessLogic.BindingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int PackageId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}
