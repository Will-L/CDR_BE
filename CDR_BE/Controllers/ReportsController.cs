using CDR_BE.Models;
using CDR_BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CDR_BE.Controllers
{
    public class ReportsController : ApiController
    {
        private CDREntities db = new CDREntities();

        [HttpGet]
        [Route("api/Reports/GetCDRentalCountReport")]
        public IEnumerable<CDRentalCountReport> GetCDRentalCountReport()
        {
            return db.CDRentalCountReport;
        }

        [HttpGet]
        [Route("api/Reports/GetRentedCDsReport")]
        /// <summary>
        /// This method will display the the data within the report table 
        /// as it has been layed out within the sql query. 
        /// </summary>
        /// <param></param>
        /// <returns></returns>


        public IEnumerable<RentedCDsViewModel> GetRentedCDsReport()
        {
            string sql = "SELECT Rental.RentalId, Staff.FirstName, CD.CDTitle, Rental.DateRented " +
                "FROM RentalItem INNER JOIN " +
                "Rental ON RentalItem.RentalId = Rental.RentalId INNER JOIN " +
                "Staff ON Rental.StaffId = Staff.StaffId INNER JOIN " +
                "CD ON RentalItem.CDId = CD.CDId";

            return db.Database.SqlQuery<RentedCDsViewModel>(sql).ToList();
        }

    }
}
