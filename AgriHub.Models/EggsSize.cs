﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace AgriHub.Models
{
    public partial class EggsSize
    {
        public EggsSize()
        {
            LayerTrans = new HashSet<LayerTrans>();
        }

        public int Id { get; set; }
        public string SizeName { get; set; }
        public string SizeDescription { get; set; }

        public virtual ICollection<LayerTrans> LayerTrans { get; set; }
    }
}