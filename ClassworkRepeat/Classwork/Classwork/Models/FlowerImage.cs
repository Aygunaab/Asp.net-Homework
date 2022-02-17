using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Models
{
    public class FlowerImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
    }
}
