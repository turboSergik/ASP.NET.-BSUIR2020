﻿using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
