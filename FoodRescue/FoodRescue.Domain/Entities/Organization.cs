using FoodRescue.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Domain.Entities
{
    public class Organization: EntityBase
    {
        public string Name { get; set; }
        public string OrgType { get; set; }
        public string Address { get; set; }
    }
}
