﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.ContratacaoHospedagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
