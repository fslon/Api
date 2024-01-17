using System;
using System.Collections.Generic;

#nullable disable

namespace TourApi.Models
{
    public partial class OrderTour
    {
        public int GoodId { get; set; }
        public int OrderId { get; set; }

        public virtual Good Good { get; set; }
        public virtual Order Order { get; set; }
    }
}
