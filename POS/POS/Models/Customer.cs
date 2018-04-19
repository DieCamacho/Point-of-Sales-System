using System;
using POS.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using POS.Models;

namespace POS.Models
{

    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180414183005_Initial")]
    public class Customer
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CustomerID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string FName { get; set; }

        [StringLength(50), Display(Name = "Name")]
        public string MInit { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string LName { get; set; }
        
        [Required]
        public int Phone_Number { get; set; }

        [Required, StringLength(50),]
        public string C_streetName { get; set; }

        [Required, StringLength(50)]
        public int C_streetNum { get; set; }

        [Required, StringLength(50)]
        public string C_City { get; set; }

        [Required]
        public int C_zipCode { get; set; }
    }
}
