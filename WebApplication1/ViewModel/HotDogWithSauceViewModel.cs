﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class HotDogWithSauceViewModel
    {
        public List<Sauce> Sauces { get; set; }
        public HotDog HotDog { get; set; }
    }
}