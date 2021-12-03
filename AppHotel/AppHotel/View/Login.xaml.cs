using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        App PropriedadesApp;

        public Login()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = "guilhermelima18";
            string senha = "123456";

            string usuarioDigitado = txtUsuario.Text;
            string senhaDigitada = txtSenha.Text;

            if (usuarioDigitado.Contains(usuario) && senhaDigitada.Contains(senha))
            {
                App.Current.Properties.Add("usuario_logado", usuarioDigitado);
                App.Current.MainPage = new View.ContratacaoHospedagem();
            }
            else
            {
                DisplayAlert("Ops", "Usuário ou senha incorretos.", "OK");
            }
        }
    }
}