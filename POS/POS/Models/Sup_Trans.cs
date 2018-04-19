using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Models
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]

    public class Sup_Trans
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderNum { get; set; }

        [Required]
        public int SupplierUpdate { get; set; }

        [Required]
        public int Transaction_ID { get; set; }

        [Required, StringLength(50), Display(Name = "Product Name")]
        public string ProductName { get; set; }
    }
}