namespace App.Models {
    class ServerData {
        private static ServerData instance;

        private string url;
        public string URLString {
            get => url;
            set => url = "http://" + value + "/configex?login=root";
        }

        private string urlForImage;
        public string URLForImage {
            get => urlForImage;
            set => urlForImage = "http://" + value;
        }

        public static ServerData GetInstance() {
            if (instance == null)
                instance = new ServerData();
            return instance;
        }
    }
}
