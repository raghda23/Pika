﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
