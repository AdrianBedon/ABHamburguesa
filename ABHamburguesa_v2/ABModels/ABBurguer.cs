﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABHamburguesa_v2.ABModels
{
    [Table("burguer")]
    public class ABBurguer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250),Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool WithExtraCheese { get; set; }
    }
}