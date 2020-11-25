using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDR_BE.ViewModels
{
    public class RentedCDsViewModel
    {
        public int RentalId { get; set; }

        public string CDTitle { get; set; }

        public string FirstName { get; set; }

        public DateTime DateRented { get; set; }
    }
}