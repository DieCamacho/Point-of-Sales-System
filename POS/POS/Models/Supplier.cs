using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Models
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Supplier
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SupplierID { get; set; }

        [Required]
        public int Order_Num { get; set; }

        [Required, StringLength(50)]
        public string SupplierName { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; }

        [Required, StringLength(50)]
        public string S_streetName { get; set; }

        [Required, StringLength(50)]
        public int S_streetNum { get; set; }

        [Required, StringLength(50)]
        public string S_City { get; set; }

        [Required, StringLength(50)]
        public string S_State { get; set; }

        [Required]
        public int S_zipCode { get; set; }
    }
}