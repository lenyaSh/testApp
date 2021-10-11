using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModel;

namespace App.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage {
        public StartPage() {
            InitializeComponent();
            BindingContext = this;
            IsBusy = false;
            ConnectButton.IsEnabled = false;
        }


        private async void ConnectToServer(object sender, EventArgs e) {
            IsBusy = true;
            try {
                ServerDataViewModel server = new ServerDataViewModel();
                server.Server.URLForImage = ServerName.Text.Trim();
                server.GetData(ServerName.Text.Trim());

                await Navigation.PushAsync(new CameraListPage(server.c_vm));
                Navigation.RemovePage(this);
            }
            catch (Exception ex) {
                IsBusy = false;
                await DisplayAlert("Ошибка получения данных с сервера", "Текст ошибки:\n" + ex.Message, "ОK");
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e) {
            if (ServerName.Text.Length > 5) {
                ConnectButton.IsEnabled = true;
            }
        }
    }
}