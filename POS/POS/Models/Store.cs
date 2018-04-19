using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Models
{

    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Store
    {
        [Key]
        [ScaffoldColumn(false)]
        public int StoreID { get; set; }

        [Required, StringLength(50), Display(Name = "Store Name")]
        public string StoreName { get; set; }


        [Required]
        public int Store_streetNum { get; set; }

        [Required, StringLength(50)]
        public string Store_streetName { get; set; }

        [Required, StringLength(50)]
        public string Store_City { get; set; }

        [Required, StringLength(50)]
        public string Store_State { get; set; }

        [Required]
        public int Store_ZipCode { get; set; }
    }
}