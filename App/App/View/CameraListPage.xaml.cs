using App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraListPage : ContentPage {
        public CameraListPage() {
            InitializeComponent();
            BindingContext = new CamerasListViewModel() { Navigation = Navigation };
        }

        public CameraListPage(CamerasListViewModel vm) {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

    }
}