using System;
using System.Collections.Generic;

#nullable disable

namespace TourApi.Models
{
    public partial class Good
    {
        public Good()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public int AirportDistance { get; set; }
        public int BeachDistance { get; set; }
        public int Rating { get; set; }
        public string Parking { get; set; }
        public int Stars { get; set; }
        public int FoodSystem { get; set; }
        public int FoodType { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Wifi { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual FoodSystem FoodSystemNavigation { get; set; }
        public virtual FoodType FoodTypeNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
