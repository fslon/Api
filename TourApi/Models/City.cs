using System;
using System.Collections.Generic;

#nullable disable

namespace TourApi.Models
{
    public partial class City
    {
        public City()
        {
            Goods = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
