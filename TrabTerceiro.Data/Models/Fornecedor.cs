﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabTerceiro.Data
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("For_ID")]
        public int ForId { get; set; }
        [Required]
        [Display(Name = "Fornecedor")]
        [Column("For_Nome")]
        [StringLength(50)]
        public string ForNome { get; set; }

        [InverseProperty("ProFornecedorNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}