﻿using PropertyManager.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Models
{
    public class LeaseModel
    {
        public int LeaseId { get; set; }
        public int PropertyId { get; set; }
        public int TenantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public RentFrequencies RentFrequency { get; set; }

        public PropertyModel Property { get; set; }
        public TenantModel Tenant { get; set; }

        

    }
}