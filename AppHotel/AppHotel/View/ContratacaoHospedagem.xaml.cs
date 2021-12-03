using AppHotel.Model;
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
    public partial class ContratacaoHospedagem : ContentPage
    {
        App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;

            lblUsuario.Text = App.Current.Properties["usuario_logado"].ToString();

            pckSuite.ItemsSource = PropriedadesApp.ListaSuites;

            // Trava a data no dia atual
            dtpckCheckIn.MinimumDate = DateTime.Now;

            // Trava a data máxima em até 6 meses da data atual
            dtpckCheckIn.MaximumDate = DateTime.Now.AddMonths(6);

            // Data de CheckOut mínima de 1 dia após o CheckIn
            dtpckCheckOut.MinimumDate = DateTime.Now.AddDays(1);

            // Data de CheckOut máxima de 6 meses + 1 dia
            dtpckCheckOut.MaximumDate = DateTime.Now.AddMonths(6).AddDays(1);
        }

        private void dtpckCheckIn_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Recupera o que o usuário selecionou de data no CheckIn
            DatePicker elemento = (DatePicker)sender;

            dtpckCheckOut.MinimumDate = elemento.Date.AddDays(1);
            dtpckCheckOut.MaximumDate = elemento.Date.AddMonths(6).AddDays(1);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage =
                    new HospedagemCalculada()
                    {
                        BindingContext = new Hospedagem()
                        {
                            QtdeAdultos = Convert.ToInt32(lblQtdeAdultos.Text),
                            QtdeCriancas = Convert.ToInt32(lblQtdeCriancas.Text),
                            QuartoEscolhido = (Suite)pckSuite.SelectedItem,
                            DataCheckIn = dtpckCheckIn.Date,
                            DataCheckOut = dtpckCheckOut.Date
                        }
                    };
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool confirmacaoSaida = await DisplayAlert("Tem certeza?", "Desconectar sua conta?", "Sim", "Não");

            if (confirmacaoSaida)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }
        }
    }
}