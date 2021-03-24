﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaTajm.Interfaces;

namespace PizzaTajm.Models
{
    public class Meat : IStuff
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
