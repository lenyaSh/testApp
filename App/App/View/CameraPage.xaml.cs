using App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraViewModel ViewModel { get; private set; }

        public CameraPage(CameraViewModel vm, bool imageSaved = false)
        {
            InitializeComponent();
            ViewModel = vm;
            ViewModel.ImageSaved = imageSaved;
            BindingContext = ViewModel;
        }
    }
}