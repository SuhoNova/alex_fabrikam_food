﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam_Food.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            InitializeComponent();
        }
    }
}
