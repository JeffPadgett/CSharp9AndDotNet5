﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
    [Index(nameof(CompanyName), Name = "CompanyNameSuppliers")]
    [Index(nameof(PostalCode), Name = "PostalCodeSuppliers")]
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("SupplierID")]
        public long SupplierId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar (40)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "nvarchar (30)")]
        public string ContactName { get; set; }
        [Column(TypeName = "nvarchar (30)")]
        public string ContactTitle { get; set; }
        [Column(TypeName = "nvarchar (60)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string Region { get; set; }
        [Column(TypeName = "nvarchar (10)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar (24)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar (24)")]
        public string Fax { get; set; }
        [Column(TypeName = "ntext")]
        public string HomePage { get; set; }

        [InverseProperty(nameof(Product.Supplier))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
