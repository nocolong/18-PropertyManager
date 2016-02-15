using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public enum RentFrequencies
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Quarterly = 4,
        BiAnually = 5,
        Anually = 6
    }


    public class Lease
    {
        public int LeaseId { get; set; }
        public int PropertyId { get; set; }
        public int TenantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public RentFrequencies RentFrequency { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}