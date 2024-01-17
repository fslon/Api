using System;
using System.Collections.Generic;

#nullable disable

namespace TourApi.Models
{
    public partial class FoodType
    {
        public FoodType()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
