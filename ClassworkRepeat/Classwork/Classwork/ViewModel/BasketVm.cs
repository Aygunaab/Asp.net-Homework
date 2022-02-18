using Classwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.ViewModel
{
    public class BasketVm
    {
        public Flower Flower { get; set; }
        public int Count { get; set; } = 1;
    }
}
