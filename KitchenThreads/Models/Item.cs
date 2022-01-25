using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenThreads.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PreparationTime { get; set; }
        public int Complexity { get; set; }
        public string CookingApparatus { get; set; }

    }
}
