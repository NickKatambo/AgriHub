﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace AgriHub.Models
{
    public partial class LayerHouse
    {
        public LayerHouse()
        {
            Layer = new HashSet<Layer>();
        }

        public int Id { get; set; }
        public int Capacity { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Layer> Layer { get; set; }
    }
}