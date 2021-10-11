using App.Models;
using System.ComponentModel;

namespace App.ViewModel {
    public class CameraViewModel {
        CamerasListViewModel cl_vm;
        public Camera Camera { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name {
            get => Camera.Name;
            set {
                if (Camera.Name != value) {
                    Camera.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public CamerasListViewModel ListViewModel {
            get => cl_vm;
            set {
                if (cl_vm != value) {
                    cl_vm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public bool IsSoundOn {
            get => Camera.IsSoundOn;
            set {
                if (Camera.IsSoundOn != value) {
                    Camera.IsSoundOn = value;
                    OnPropertyChanged("IsSoundOn");
                }
            }
        }
        public string ServerName {
            get => Camera.ServerName;
            set {
                if (Camera.ServerName != value) {
                    Camera.ServerName = value;
                    OnPropertyChanged("Phone");
                }
            }
        }


        private bool imageSaved;
        public bool ImageSaved {
            get => imageSaved;
            set {
                if (imageSaved != value) {
                    imageSaved = value;
                    OnPropertyChanged("");
                }
            }
        }

        public CameraViewModel(string name, string serverName, bool isSoundOn, string id) {
            Camera = new Camera() { Name = name, ServerName = serverName, IsSoundOn = isSoundOn, Id = id };
        }

        public bool IsValid => (!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(ServerName.Trim())) ||
                    (!string.IsNullOrEmpty(Name.Trim()));

        private void OnPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
