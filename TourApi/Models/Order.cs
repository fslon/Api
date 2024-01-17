using System;
using System.Collections.Generic;

#nullable disable

namespace TourApi.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public virtual Good Tour { get; set; }
    }
}
