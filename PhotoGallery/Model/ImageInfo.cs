using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhotoGallery
{
    public class ImageInfo : INotifyPropertyChanged
    {
        private string imageName;
        private string image;
        private string size;
        private DateTime dateTime;
        private bool isFavorite;

        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                OnPropertyChanged("ImageName");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
            }
        }

        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                isFavorite = value;
                OnPropertyChanged("IsFavorite");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
