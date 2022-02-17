using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public byte DiscountPercent { get; set; }
        public List<Flower> Flowers { get; set; }
    }
}
