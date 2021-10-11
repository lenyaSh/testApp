using Android.Provider;
using App.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace App.ViewModel {
    public class CamerasListViewModel {
        public ObservableCollection<CameraViewModel> Cameras { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private CameraViewModel selectedCamera;
        public INavigation Navigation { get; set; }

        public CamerasListViewModel() {
            //TODO: сделать camera dto и получить в него данные с xml api сайта
            Cameras = new ObservableCollection<CameraViewModel>();
        }

        public CameraViewModel SelectedCamera {
            get => selectedCamera;
            set {
                if (selectedCamera != value) {
                    CameraViewModel tempCamera = value;
                    selectedCamera = null;
                    OnPropertyChanged("SelectedCamera");

                    try {
                        ServerDataViewModel server = new ServerDataViewModel();
                        System.Net.WebClient wc = new System.Net.WebClient();
                        string downloadURL =
                            server.Server.URLForImage + "/mobile?channelid=" + tempCamera.Camera.Id + "&login=root&password=&oneframeonly=true";

                        string requestResult = wc.DownloadString(downloadURL);
                        bool imageSaved = SaveImageFromRequest(requestResult);

                        Navigation.PushAsync(new CameraPage(tempCamera), true);
                    }
                    catch (Exception ex) {

                        Navigation.PushAsync(new CameraPage(tempCamera));
                    }

                }
            }
        }

        private bool SaveImageFromRequest(string answer) {
            try {
                string pattern = @"Content-Length:\s\d+\r\n\r\n";
                byte[] bytesOfImage = Encoding.ASCII.GetBytes(Regex.Split(answer, pattern).Last());

                bool result = byteArrayToImage(bytesOfImage);

                return result;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        bool byteArrayToImage(byte[] source) {
            try {
                File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "output.jpg") , source);

                //image.Save(Environment.SpecialFolder.Personal + @"/output.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);  // Or Png

                return true;
            }
            catch (Exception ex) {
                throw new Exception("Не удалось сохранить изображение");
            }
        }

        protected void OnPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
