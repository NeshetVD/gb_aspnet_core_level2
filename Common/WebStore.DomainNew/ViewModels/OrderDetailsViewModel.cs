﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public CartViewModel CartViewModel { get; set; }
    }
}
