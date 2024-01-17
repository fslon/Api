using System;
using System.Collections.Generic;

#nullable disable

namespace TourApi.Models
{
    public partial class FoodSystem
    {
        public FoodSystem()
        {
            Goods = new HashSet<Good>();
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
