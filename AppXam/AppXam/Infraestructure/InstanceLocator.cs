﻿using AppXam.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXam.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
