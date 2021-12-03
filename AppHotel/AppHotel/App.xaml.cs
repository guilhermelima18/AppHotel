using AppHotel.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Globalization;

namespace AppHotel
{
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            InitializeComponent();

            if (Properties.ContainsKey("usuario_logado"))
            {
                MainPage = new NavigationPage(new View.ContratacaoHospedagem());
            }
            else
            {
                MainPage = new NavigationPage(new View.Login());
            }
        }

        public List<Suite> ListaSuites = new List<Suite>
        {
            new Suite()
            {
                Nome = "Super Luxo",
                DiariaAdulto = 110.0,
                DiariaCrianca = 55.0,
            },
            new Suite()
            {
                Nome = "Executiva",
                DiariaAdulto = 90.0,
                DiariaCrianca = 45.0,
            },
            new Suite()
            {
                Nome = "Crise",
                DiariaAdulto = 45.0,
                DiariaCrianca = 20.0,
            }
        };

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
